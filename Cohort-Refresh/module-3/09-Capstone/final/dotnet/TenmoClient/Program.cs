using System;
using System.Collections.Generic;
using TenmoClient.Data;

namespace TenmoClient
{
    class Program
    {
        private static readonly ConsoleService consoleService = new ConsoleService();
        private static readonly AuthService authService = new AuthService();
        private static readonly APIService apiService = new APIService();

        static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            int loginRegister = -1;
            while (loginRegister != 1 && loginRegister != 2)
            {
                Console.WriteLine("Welcome to TEnmo!");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Register");
                Console.Write("Please choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out loginRegister))
                {
                    Console.WriteLine("Invalid input. Please enter only a number.");
                }
                else if (loginRegister == 1)
                {
                    while (!UserService.IsLoggedIn()) //will keep looping until user is logged in
                    {
                        LoginUser loginUser = consoleService.PromptForLogin();
                        API_User user = authService.Login(loginUser);
                        if (user != null)
                        {
                            UserService.SetLogin(user);
                        }
                    }
                }
                else if (loginRegister == 2)
                {
                    bool isRegistered = false;
                    while (!isRegistered) //will keep looping until user is registered
                    {
                        LoginUser registerUser = consoleService.PromptForLogin();
                        isRegistered = authService.Register(registerUser);
                        if (isRegistered)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Registration successful. You can now log in.");
                            loginRegister = -1; //reset outer loop to allow choice for login
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }

            MenuSelection();
        }

        private static void MenuSelection()
        {
            int menuSelection = -1;
            while (menuSelection != 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Welcome to TEnmo! Please make a selection: ");
                Console.WriteLine("1: View your current balance");
                Console.WriteLine("2: View your past transfers"); //view details through here
                Console.WriteLine("3: View your pending requests"); //ability to approve/reject through here
                Console.WriteLine("4: Send TE bucks");
                Console.WriteLine("5: Request TE bucks");
                Console.WriteLine("6: Log in as different user");
                Console.WriteLine("0: Exit");
                Console.WriteLine("---------");
                Console.Write("Please choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("Invalid input. Please enter only a number.");
                }
                else if (menuSelection == 1)
                {
                    decimal balance = apiService.GetBalance();
                    if (balance != decimal.MinValue)
                    {
                        Console.WriteLine("Your TE bucks balance is " + balance.ToString("C"));
                    }
                }
                else if (menuSelection == 2)
                {
                    List<Transfer> transfers = apiService.GetTransfers();
                    if (transfers != null)
                    {
                        consoleService.PrintTransfers(transfers);
                        if (transfers.Count > 0)
                        {
                            int transferId = consoleService.PromptForTransferID("view");
                            if (transferId > 0)
                            {
                                Transfer transfer = apiService.GetTransfer(transferId);
                                if (transfer != null)
                                {
                                    consoleService.PrintTransfer(transfer);
                                }
                            }
                        }
                    }
                }
                else if (menuSelection == 3)
                {
                    List<Transfer> transfers = apiService.GetPendingTransfers();
                    if (transfers != null)
                    {
                        consoleService.PrintTransfers(transfers);
                        if (transfers.Count > 0)
                        {
                            string choice = consoleService.PromptForApproveOrReject();
                            if (choice != null)
                            {
                                int transferId = consoleService.PromptForTransferID(choice);
                                if (transferId > 0)
                                {
                                    if (choice == "approve")
                                    {
                                        Transfer transfer = apiService.ApproveTransfer(transferId);
                                        if (transfer.TransferStatus == TransferStatus.Approved)
                                        {
                                            Console.WriteLine("Approval was successful");
                                            consoleService.PrintTransfer(transfer);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Approval was not successful");
                                        }
                                    }
                                    else if (choice == "reject")
                                    {
                                        Transfer transfer = apiService.RejectTransfer(transferId);
                                        if (transfer.TransferStatus == TransferStatus.Rejected)
                                        {
                                            Console.WriteLine("Rejection was successful");
                                            consoleService.PrintTransfer(transfer);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Rejection was not successful");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (menuSelection == 4)
                {
                    NewTransfer newTransfer = consoleService.PromptForTransfer(TransferType.Send);
                    if (newTransfer != null)
                    {
                        Transfer addedTransfer = apiService.AddTransfer(newTransfer);

                        if (addedTransfer != null)
                        {
                            consoleService.PrintTransfer(addedTransfer);
                        }
                    }
                }
                else if (menuSelection == 5)
                {
                    NewTransfer newTransfer = consoleService.PromptForTransfer(TransferType.Request);
                    if (newTransfer != null)
                    {
                        Transfer addedTransfer = apiService.AddTransfer(newTransfer);

                        if (addedTransfer != null)
                        {
                            consoleService.PrintTransfer(addedTransfer);
                        }
                    }
                }
                else if (menuSelection == 6)
                {
                    Console.WriteLine("");
                    UserService.SetLogin(new API_User()); //wipe out previous login info
                    Run(); //return to entry point
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }
            }
        }
    }
}
