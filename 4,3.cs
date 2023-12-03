using System;
using System.Collections.Generic;

// Базовий клас "Комп'ютер"
public class Computer
{
    public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OS { get; set; }

    public Computer(string ipAddress, int power, string os)
    {
        IPAddress = ipAddress;
        Power = power;
        OS = os;
    }
}

// Інтерфейс "Підключення"
public interface IConnectable
{
    void Connect(Computer target);
    void Disconnect(Computer target);
    void TransmitData(Computer target, string data);
    void ReceiveData(string data);
}

// Клас "Сервер"
public class Server : Computer, IConnectable
{
    public Server(string ipAddress, int power, string os)
        : base(ipAddress, power, os)
    {
    }

    public void Connect(Computer target)
    {
        Console.WriteLine($"Server {IPAddress} is connected to {target.IPAddress}.");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Server {IPAddress} is disconnected from {target.IPAddress}.");
    }

    public void TransmitData(Computer target, string data)
    {
        Console.WriteLine($"Server {IPAddress} is transmitting data to {target.IPAddress}: {data}");
    }

    public void ReceiveData(string data)
    {
        Console.WriteLine($"Server {IPAddress} received data: {data}");
    }
}

// Клас "Робоча станція"
public class Workstation : Computer, IConnectable
{
    public Workstation(string ipAddress, int power, string os)
        : base(ipAddress, power, os)
    {
    }

    public void Connect(Computer target)
    {
        Console.WriteLine($"Workstation {IPAddress} is connected to {target.IPAddress}.");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Workstation {IPAddress} is disconnected from {target.IPAddress}.");
    }

    public void TransmitData(Computer target, string data)
    {
        Console.WriteLine($"Workstation {IPAddress} is transmitting data to {target.IPAddress}: {data}");
    }

    public void ReceiveData(string data)
    {
        Console.WriteLine($"Workstation {IPAddress} received data: {data}");
    }
}

// Клас "Маршрутизатор"
public class Router : Computer, IConnectable
{
    public Router(string ipAddress, int power, string os)
        : base(ipAddress, power, os)
    {
    }

    public void Connect(Computer target)
    {
        Console.WriteLine($"Router {IPAddress} is connected to {target.IPAddress}.");
    }

    public void Disconnect(Computer target)
    {
        Console.WriteLine($"Router {IPAddress} is disconnected from {target.IPAddress}.");
    }

    public void TransmitData(Computer target, string data)
    {
        Console.WriteLine($"Router {IPAddress} is transmitting data to {target.IPAddress}: {data}");
    }

    public void ReceiveData(string data)
    {
        Console.WriteLine($"Router {IPAddress} received data: {data}");
    }
}

// Клас "Мережа"
public class Network
{
    private List<IConnectable> devices;

    public Network(List<IConnectable> devices)
    {
        this.devices = devices;
    }

    public void SimulateInteraction()
    {
        Random random = new Random();

        foreach (var device in devices)
        {
            var otherDevice = devices[random.Next(devices.Count)];
            if (device != otherDevice)
            {
                device.Connect(otherDevice as Computer);
                device.TransmitData(otherDevice as Computer, "Sample data");
                device.Disconnect(otherDevice as Computer);
            }
        }
    }
}

// Приклад використання:

class Program
{
    static void Main()
    {
        Server server = new Server("192.168.1.1", 1000, "Windows Server");
        Workstation workstation = new Workstation("192.168.1.2", 500, "Windows 10");
        Router router = new Router("192.168.1.3", 800, "RouterOS");

        List<IConnectable> devices = new List<IConnectable> { server, workstation, router };
        Network network = new Network(devices);
        network.SimulateInteraction();
    }
}
