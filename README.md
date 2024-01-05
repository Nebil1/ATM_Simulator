# ATM Simulator

ATM Simulator is a console-based application that simulates the functionality of an Automated Teller Machine (ATM).

## Running the Project

To run the ATM Simulator, follow these steps:

1. Clone the repository to your local machine.
2. Open the folder in Visual Studio Code.
3. Open the terminal in Visual Studio Code (`View -> Terminal`).
4. Change the directory to the project folder by using the `cd` command. For example, if your project is in a folder named `ATMSimulator`, you would type `cd ATMSimulator`.
5. Run the command `dotnet build` to build the solution.
6. Run the command `dotnet run` to start the application.

After the application starts, you can use the console to interact with the ATM.

## Features

- User Authentication: The application authenticates users based on their card number and PIN.
- Balance Inquiry: Users can check their account balance.
- Deposit: Users can deposit money into their account.
- Withdraw: Users can withdraw money from their account.
- Transaction History: The application keeps a record of all transactions performed by the user.

## Logging

The application logs successful logins, user activity, and system errors. The logs are saved in the 'logs' folder in the following files:

- `successfulLogins.txt`: Contains a record of all successful logins.
- `userActivity.txt`: Contains a record of all user activity.
- `systemErrors.txt`: Contains a record of all system errors.

## Development

The ATM Simulator is developed in C#. It uses a simple file-based database to store user accounts and transaction history.

## Contributing

Contributions are welcome. Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.
