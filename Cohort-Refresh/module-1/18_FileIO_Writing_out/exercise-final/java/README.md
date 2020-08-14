# File I/O Part 2 Solutions

## FindAndReplace

Write a program that can be used to replace all occurrences of one word with another word.  

The program should prompt the user for the following values:

* The search word
* The word to replace the search word with
* The source file  *This must be an existing file.  If the user enters an invalid source file, the program indicates this and exits.*
* The destination file.  *The program creates a copy of the source file with the requested replacements at this location.  If the file already exists, it should be overwritten. If the user enters an invalid destination file, the program indicates this and exits.*

## FizzWriter

Create a program to write out the result of FizzBuzz (1 to 300) to a file.

Note: this version of FizzBuzz has additional requirements.

* If the number is divisible by 3, or contains a 3, print “Fizz.”
* If the number is divisible by 5, or contains a 5, print “Buzz.”
* If the number is divisible by 3 and 5, print “FizzBuzz.”
* Otherwise, print the number.

The program should prompt the user for the following values:

* The destination file.  *If the file already exists, it should be overwritten. If the user enters an invalid destination file, the program indicates this and exits.*


## File Splitter (Challenge)

Develop an application that takes a significantly large input file and splits it into smaller file chunks. These types of files were common back when floppy disks were smaller and couldn't hold a larger program on their own.

The program should prompt the user for the following values:
* The source file  *This must be an existing file.  If the user enters an invalid source file, the program indicates this and exits.*
* The maximum number of lines in each output file.

Each output file that is created should have a sequential number assigned to it. For example, given `fizzbuzz.txt` as the source filename, the output filenames should be `fizzbuzz-1.txt, fizzbuzz-2.txt, ...`.


