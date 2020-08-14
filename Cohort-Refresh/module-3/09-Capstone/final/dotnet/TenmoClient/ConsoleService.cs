using System;
using System.Collections.Generic;
using TenmoClient.Data;

namespace TenmoClient
{
    public class ConsoleService
    {
        public void PrintTransfers(List<Transfer> transfers)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Transfers");
            Console.WriteLine("--------------------------------------------");
            int currentUser = UserService.GetUserId();

            if (transfers.Count == 0)
            {
                Console.WriteLine("There are no transfers to list");
            }
            foreach (Transfer transfer in transfers)
            {
                //show only the "From" or "To" for the other user in the transaction
                string fromTo;
                if (currentUser == transfer.AccountFrom.UserId)
                {
                    fromTo = $"To: {transfer.AccountTo.Username}";
                }
                else
                {
                    fromTo = $"From: {transfer.AccountFrom.Username}";
                }
                Console.WriteLine($"{transfer.TransferId} | {fromTo} | {transfer.Amount:C}");
            }
        }

        public void PrintTransfer(Transfer transfer)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Transfer Details");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine(" Id: " + transfer.TransferId);
            Console.WriteLine(" From: " + transfer.AccountFrom.Username);
            Console.WriteLine(" To: " + transfer.AccountTo.Username);
            Console.WriteLine(" Type: " + transfer.TransferType.ToString());
            Console.WriteLine(" Status: " + transfer.TransferStatus.ToString());
            Console.WriteLine(" Amount: " + transfer.Amount.ToString("C"));
        }

        public void PrintUsers(List<User> users)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Users");
            Console.WriteLine("--------------------------------------------");
            foreach (User user in users)
            {
                Console.WriteLine($"{user.UserId} | Username: {user.Username} | Email: {user.Email}");
            }
        }

        public string PromptForApproveOrReject()
        {
            Console.WriteLine("");
            Console.WriteLine("Do you want to approve or reject any of these transactions?");
            Console.WriteLine("1: Approve");
            Console.WriteLine("2: Reject");
            Console.WriteLine("0: Don't approve or reject");
            Console.Write("Please choose an option: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return null;
            }
            else
            {
                if (choice == 1)
                {
                    return "approve";
                }
                else if (choice == 2)
                {
                    return "reject";
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Prompts for transfer ID to view, approve, or reject
        /// </summary>
        /// <param name="action">String to print in prompt. Expected values are "Approve" or "Reject" or "View"</param>
        /// <returns>ID of transfers to view, approve, or reject</returns>
        public int PromptForTransferID(string action)
        {
            Console.WriteLine("");
            Console.Write("Please enter transfer ID to " + action + " (0 to cancel): ");
            if (!int.TryParse(Console.ReadLine(), out int auctionId))
            {
                Console.WriteLine("Invalid input. Only input a number.");
                return 0;
            }
            else
            {
                return auctionId;
            }
        }

        /// <summary>
        /// Prompts for details on new transfers
        /// </summary>
        /// <returns>A NewTransfer object containing info to send to server</returns>
        public NewTransfer PromptForTransfer(TransferType transferType)
        {
            //user to/from
            Console.Write($"Enter ID of user you are {(transferType == TransferType.Request ? "requesting from" : "sending to")}: ");
            string userInput = Console.ReadLine();

            if (!int.TryParse(userInput, out int otherUser))
            {
                Console.WriteLine("Invalid input. Please enter only a number.");
                return null;
            }

            //amount
            Console.Write($"Enter amount to {transferType.ToString().ToLower()}: $");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid input. Please enter only a number.");
                return null;
            }

            int currentUser = UserService.GetUserId();

            NewTransfer newTransfer = new NewTransfer()
            {
                TransferType = transferType,
                UserFrom = transferType == TransferType.Request ? otherUser : currentUser,
                UserTo = transferType == TransferType.Request ? currentUser : otherUser,
                Amount = amount
            };

            return newTransfer;
        }

        public LoginUser PromptForLogin()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            string password = GetPasswordFromConsole("Password: ");

            LoginUser loginUser = new LoginUser
            {
                Username = username,
                Password = password
            };
            return loginUser;
        }

        private string GetPasswordFromConsole(string displayMessage)
        {
            string pass = "";
            Console.Write(displayMessage);
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Backspace Should Not Work
                if (!char.IsControl(key.KeyChar))
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Remove(pass.Length - 1);
                        Console.Write("\b \b");
                    }
                }
            }
            // Stops Receving Keys Once Enter is Pressed
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine("");
            return pass;
        }
    }
}
