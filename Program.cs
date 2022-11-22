using Newtonsoft.Json;
using Windows.Storage;

class WorkingATM
{
    public static List<Client> Clients = new List<Client>();
    public static List<AmountOfBills> billList = new List<AmountOfBills>();
    public static void Main()
    {
        while (true)
        {
            LoadJson();
            LoadAmountOfBillsInMachine();
            NotificationAboutShortageOfBills();

            int[] Banknotes = new int[] { 50, 100, 200, 500 };
            Random rand = new Random();

            Console.WriteLine("Welcome at our ATM");
            Console.WriteLine("Please pass your ID:");
            int id = int.Parse(Console.ReadLine());

            if (id.ToString().Length == 6)
            {
                var MoneyAmount = 0;
                var DidItBreak = false;
                var tempClient = new Client();
                for (int i = 0; i < Clients.Count(); i++)
                {
                    if (Clients[i].Id == id)
                    {
                        MoneyAmount = Clients[i].AmountUserHasOnHisAccount;
                        DidItBreak = true;
                        tempClient = Clients[i];
                        break;
                    }
                }
                if (DidItBreak)
                {
                    Console.WriteLine($"A client with id {id} was found!");
                    Thread.Sleep(1000);
                    Console.Clear();

                    Console.WriteLine($"Enter the amount you want to withdraw:");
                    Console.WriteLine("1 - 50");
                    Console.WriteLine("2 - 100");
                    Console.WriteLine("3 - 150");
                    Console.WriteLine("4 - 200");
                    Console.WriteLine("5 - 500");
                    Console.WriteLine("6 - Diffrent Amount");
                    Console.WriteLine("7 - Exit");

                    var userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            if (MoneyAmount >= 50)
                            {
                                Console.WriteLine($"Withdrawing 50zl in 1 banknote 50zl.");
                                SerializedJsonAmountUserHasOnHisAccountEdit(tempClient, tempClient.AmountUserHasOnHisAccount - 50);
                                Console.WriteLine("Thank you for using our ATM :-)");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("You have not enough money in your account.");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            break;

                        case "2":
                            if (MoneyAmount >= 100)
                            {
                                var random = rand.Next(0, 1);
                                Console.WriteLine($"Withdrawing 100zl in {100 / Banknotes[random]} banknotes {Banknotes[random]}zl.");
                                SerializedJsonAmountUserHasOnHisAccountEdit(tempClient, tempClient.AmountUserHasOnHisAccount - 100);
                                Console.WriteLine("Thank you for using our ATM :-)");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("You have not enough money in your account.");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            break;

                        case "3":
                            if (MoneyAmount >= 150)
                            {
                                var random = rand.Next(0, 1);
                                Console.WriteLine($"Withdrawing 150zl in {150 / Banknotes[random]} banknotes {Banknotes[random]}zl.");
                                SerializedJsonAmountUserHasOnHisAccountEdit(tempClient, tempClient.AmountUserHasOnHisAccount - 150);
                                Console.WriteLine("Thank you for using our ATM :-)");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("You have not enough money in your account.");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            break;

                        case "4":
                            if (MoneyAmount >= 200)
                            {
                                var random = rand.Next(0, 2);
                                Console.WriteLine($"Withdrawing 200zl in {200 / Banknotes[random]} banknotes {Banknotes[random]}zl.");
                                SerializedJsonAmountUserHasOnHisAccountEdit(tempClient, tempClient.AmountUserHasOnHisAccount - 200);
                                Console.WriteLine("Thank you for using our ATM :-)");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("You have not enough money in your account.");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            break;

                        case "5":
                            if (MoneyAmount >= 500)
                            {
                                var random = rand.Next(0, 3);
                                if (random == 2)
                                {
                                    Console.WriteLine($"Withdrawing 500zl in 2 banknotes 200zl and 1 banknote 100zl.");
                                    SerializedJsonAmountUserHasOnHisAccountEdit(tempClient, tempClient.AmountUserHasOnHisAccount - 500);
                                    Console.WriteLine("Thank you for using our ATM :-)");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine($"Withdrawing 500zl in {500 / Banknotes[random]} banknotes {Banknotes[random]}zl.");
                                    SerializedJsonAmountUserHasOnHisAccountEdit(tempClient, tempClient.AmountUserHasOnHisAccount - 500);
                                    Console.WriteLine("Thank you for using our ATM :-)");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                            }
                            else
                            {
                                Console.WriteLine("You have not enough money in your account.");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            break;

                        case "6":
                            Console.WriteLine("Enter the amount you want withdraw:");
                            var amountPaid = int.Parse(Console.ReadLine());
                            if (MoneyAmount >= amountPaid)
                            {
                                if (amountPaid % 50 == 0)
                                {
                                    var random = rand.Next(0, 3);
                                    Console.WriteLine($"Withdrawing {amountPaid}zl in {amountPaid / Banknotes[random]} banknotes {Banknotes[random]}zl.");
                                    SerializedJsonAmountUserHasOnHisAccountEdit(tempClient, tempClient.AmountUserHasOnHisAccount - amountPaid);
                                    Console.WriteLine("Thank you for using our ATM :-)");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                                else
                                {
                                    Console.WriteLine("The amount entered is incorrect.");
                                    Thread.Sleep(2000);
                                    Console.Clear();
                                }
                            }
                            else
                            {
                                Console.WriteLine("You have not enough money in your account.");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            break;

                        case "7":
                            Console.Clear();
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("You passed an incorrect sign!");
                            Thread.Sleep(2000);
                            Console.Clear();
                            break;
                    }
                    DidItBreak = false;
                }
                else
                {
                    Console.WriteLine("Client not found.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            else if (id == 000) //Admin Panel
            {
                Console.Clear();
                Console.WriteLine("Password:");
                var pass = Console.ReadLine();
                if (pass == "admin1")
                {
                    Console.WriteLine("You have successfully logged in to the admin panel!");
                    Console.WriteLine("Select the operations you want to perform:");
                    Console.WriteLine("1 - Add Client");
                    Console.WriteLine("2 - Edit Client Id");
                    Console.WriteLine("3 - Edit Amount of customer money");
                    Console.WriteLine("4 - Delete Client");
                    Console.WriteLine("5 - Addition of banknotes");
                    Console.WriteLine("6 - Exit");
                    var tempUserInput = Console.ReadLine();

                    switch (tempUserInput)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("Enter Customer ID:");
                            var newClientId = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter the amount of money in the customer account that you want to set:");
                            var newClientAmount = int.Parse(Console.ReadLine());
                            Client newClient = new Client()
                            {
                                Id = newClientId,
                                AmountUserHasOnHisAccount = newClientAmount,
                            };
                            SerializedJsonNew(newClient);
                            Thread.Sleep(2000);
                            Console.WriteLine($"You have successfully created a new customer with an ID {newClient.Id}");
                            Thread.Sleep(2000);
                            Console.Clear();
                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("Enter Customer ID:");
                            var tempClientId = int.Parse(Console.ReadLine());
                            if (Clients.Any(x => x.Id == tempClientId))
                            {
                                var editKlient = Clients[Clients.FindIndex(x => x.Id == tempClientId)];
                                Console.WriteLine("Enter new Id:");
                                var newId = int.Parse(Console.ReadLine());
                                SerializedJsonIdEdit(editKlient, newId);
                            }
                            else
                            {
                                Console.WriteLine("There is no customer with such an Id.");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            break;

                        case "3":
                            Console.Clear();
                            Console.WriteLine("Enter new Id:");
                            var tempClientAmount = int.Parse(Console.ReadLine());
                            if (Clients.Any(x => x.Id == tempClientAmount))
                            {
                                var editClient = Clients[Clients.FindIndex(x => x.Id == tempClientAmount)];
                                Console.WriteLine("Enter a new amount of money:");
                                var newId = int.Parse(Console.ReadLine());
                                SerializedJsonAmountUserHasOnHisAccountEdit(editClient, newId);
                            }
                            else
                            {
                                Console.WriteLine("There is no customer with such an Id.");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("Enter new Id:");
                            var tempClient = int.Parse(Console.ReadLine());
                            if (Clients.Any(x => x.Id == tempClient))
                            {
                                var editClient = Clients[Clients.FindIndex(x => x.Id == tempClient)];
                                SerializedJsonRemove(editClient);
                                Console.WriteLine($"You have successfully removed the customer with an Id {tempClient}");
                                Thread.Sleep(3000);
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("There is no customer with such an Id.");
                                Thread.Sleep(2000);
                                Console.Clear();
                            }
                            break;

                        case "5":
                            for(int i = 0; i < 4; i++)
                            {
                                Console.WriteLine($"How many banknotes with denomination of {Banknotes[i]}zl are you adding?");
                                var amount = int.Parse(Console.ReadLine());
                                var objOfBills = billList[i];
                                SerializedJsonBillsAmountEdit(objOfBills, amount);
                            }
                            Console.Clear();
                            Console.WriteLine("You have successfully added banknotes to the ATM.");
                            Thread.Sleep(2000);
                            Console.Clear();
                            break;

                        case "6":
                            Console.Clear();
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("You passed an incorrect sign!");
                            Thread.Sleep(2000);
                            Console.Clear();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Password incorrect.");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Invalid customer ID entered!");
                Thread.Sleep(2500);
                Console.Clear();
            }
        }
    }
    public static void NotificationAboutShortageOfBills()
    {
        if(billList.Any(x => x.Amount < 50))
        {
            var tempListOfBills = billList.FindAll(x => x.Amount < 50);
            foreach(var bill in tempListOfBills)
            {
                Console.WriteLine($"There is Shortage Of {bill.Denomination}");
            }
        }
        
    }
    public static void LoadJson()
    {
        using (StreamReader read = new StreamReader("Clients.json"))
        {
            string json = read.ReadToEnd();
            Clients = JsonConvert.DeserializeObject<List<Client>>(json);
        }
    }
    public static void LoadAmountOfBillsInMachine()
    {
        using (StreamReader read = new StreamReader("AmountOfBills.json"))
        {
            string json = read.ReadToEnd();
            billList = JsonConvert.DeserializeObject<List<AmountOfBills>>(json);
        }
    }
    
    public static async void SerializedJsonNew(Client client)
    {
        var file = await ApplicationData.Current.LocalFolder.GetFileAsync("Clients.json");
        var jsonString = await FileIO.ReadTextAsync(file);
        var clientList = JsonConvert.DeserializeObject<List<Client>>(jsonString);
        clientList.Add(client);
        var updatedJsonString = JsonConvert.SerializeObject(clientList);
        await FileIO.WriteTextAsync(file, updatedJsonString);
    }
    public static async void SerializedJsonRemove(Client client)
    {
        var file = await ApplicationData.Current.LocalFolder.GetFileAsync("Clients.json");
        var jsonString = await FileIO.ReadTextAsync(file);
        var clientList = JsonConvert.DeserializeObject<List<Client>>(jsonString);
        clientList.Remove(client);
        var updatedJsonString = JsonConvert.SerializeObject(clientList);
        await FileIO.WriteTextAsync(file, updatedJsonString);
    }
    public static async void SerializedJsonBillsAmountEdit(AmountOfBills bill, int amount)
    {
        var file = await ApplicationData.Current.LocalFolder.GetFileAsync("AmountOfBills.json");
        var jsonString = await FileIO.ReadTextAsync(file);
        var listBill = JsonConvert.DeserializeObject<List<AmountOfBills>>(jsonString);
        var newBill = new AmountOfBills()
        {
            Amount = bill.Amount + amount,
            Denomination = bill.Denomination,
        };
        listBill.RemoveAt(listBill.FindIndex(x => x.Denomination == bill.Denomination));
        listBill.Add(newBill);
        var updatedJsonString = JsonConvert.SerializeObject(listBill);
        await FileIO.WriteTextAsync(file, updatedJsonString);
    }
    public static async void SerializedJsonIdEdit(Client client, int editId)
    {
        var file = await ApplicationData.Current.LocalFolder.GetFileAsync("Clients.json");
        var jsonString = await FileIO.ReadTextAsync(file);
        var clientList = JsonConvert.DeserializeObject<List<Client>>(jsonString);
        var newClient = new Client()
        {
            Id = editId,
            AmountUserHasOnHisAccount = client.AmountUserHasOnHisAccount,
        };
        clientList.RemoveAt(clientList.FindIndex(x => x.Id == client.Id));
        clientList.Add(newClient);
        var updatedJsonString = JsonConvert.SerializeObject(clientList);
        await FileIO.WriteTextAsync(file, updatedJsonString);
    }
    public static async void SerializedJsonAmountUserHasOnHisAccountEdit(Client client, int editAmountUserHasOnHisAccount)
    {
        var file = await ApplicationData.Current.LocalFolder.GetFileAsync("Clients.json");
        var jsonString = await FileIO.ReadTextAsync(file);
        var clientList = JsonConvert.DeserializeObject<List<Client>>(jsonString);
        var newClient = new Client()
        {
            Id = client.Id,
            AmountUserHasOnHisAccount = editAmountUserHasOnHisAccount,
        };
        clientList.RemoveAt(clientList.FindIndex(x => x.AmountUserHasOnHisAccount == client.AmountUserHasOnHisAccount));
        clientList.Add(newClient);
        var updatedJsonString = JsonConvert.SerializeObject(clientList);
        await FileIO.WriteTextAsync(file, updatedJsonString);
    }
}