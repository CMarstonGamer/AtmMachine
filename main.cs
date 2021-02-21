using System;

class MainClass {

private static int balance, deposit, withdraw, pin, limit;

public MainClass(int userBalance){
  
  balance = userBalance;
  pin = 1234;
  limit = 500;
}
public void setBalance(int newBalance){
  balance = newBalance;
}
public void setPin(int newPin){
  pin = newPin;
}
public string getBalance(){
  return "Your balance is £" + balance;
}
public void setLimit(int newLimit){
  limit = newLimit;
}
public string getLimit(){
  return "Your withdrawal limit is £" + limit;
}
public static void depositFunds(){
Console.WriteLine("Please enter how much you wish to deposit");
int depositValue = int.Parse(Console.ReadLine());
balance = balance + depositValue;
Console.WriteLine("You have deposited: " + depositValue + " and your new balance is: £" + balance);
atmMenu();
}
public static void withdrawFunds(){
Console.WriteLine("Please enter how much you wish to withdraw");
int withdrawalValue = int.Parse(Console.ReadLine());
if (withdrawalValue > limit || withdrawalValue > balance){
  Console.WriteLine("You cannot withdraw more than your limit");
  withdrawFunds();
}
else if (withdrawalValue <= balance && withdrawalValue <= limit){
balance = balance - withdrawalValue;
limit = limit - withdrawalValue;
Console.WriteLine("You have withdrawn: £" + withdrawalValue + " and your new balance is: £" + balance + " and your new limit is: £"+ limit);
atmMenu();
} else {
  withdrawFunds();
}
}
public static void enterPin(){
Console.WriteLine("Please enter your pin: ");
int userPin = int.Parse(Console.ReadLine());
if (userPin == pin){
  atmMenu();
} else {
  Console.WriteLine("Incorrect pin");
  enterPin();
}
}
public static void atmMenu(){
  Console.WriteLine("Please select what you would like to do\nSee Balance\nDeposit\nWithdraw Funds \nExit");
  string userInput = Console.ReadLine();
  if (userInput.ToLower().Equals("see balance")){
    Console.WriteLine("Current balance is: £" + balance);
    atmMenu();
  } else if (userInput.ToLower().Equals("deposit")){
    depositFunds();
  } else if (userInput.ToLower().Equals("withdraw funds")){
    withdrawFunds();
  } else if (userInput.ToLower().Equals("exit")){
    System.Environment.Exit(0);
  } else {
    Console.WriteLine("Command not found.");
    atmMenu();
  }

}





  public static void Main (string[] args) {
    MainClass account = new MainClass(10000);
    account.setPin(3345);
    enterPin();
  }
}