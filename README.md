# Spare parts Inventory 🚚

## Introduction
Hello and welcome to my first ambitious project! You might be wondering, what exactly is this project? Well, it's an inventory system for spare parts. While this might sound boring to some, for me, it's incredibly exciting.

## Table of Contents
- [Introduction](#introduction)
- [Why an inventory app, you ask?](#why-an-inventory-app-you-ask)
- [Which technology to use?](#which-technology-to-use)
- [Which type of web app must I choose?](#which-type-of-web-app-must-i-choose)
- [Which are my entities?](#which-are-my-entities)
- [Which type of architecture to use?](#which-type-of-architecture-to-use)
- [What about the views?](#What-about-the-views)
- [Getting Started](#Getting-Started)

### Why an inventory app, you ask?

Let me take you back a few years. I used to work as a mechanic, but then I transitioned to the spare parts sales department. Back then, everything was managed using paper registers. Seeing the need for a change, I decided to incorporate Excel into our system. Now that you understand my motivation, let me guide you through my thoughts:

### Which type of web app must I choose?

First, a web API, then an MVC app, and finally, I will use React.

### Which technology to use?

[![My Skills](https://skillicons.dev/icons?i=cs,dotnet,postgres,react,js,html,css)](https://skillicons.dev)

### Which are my entities?

Well, it all starts with the UML class diagram. It took me many hours to figure out the best option that fulfills my requirements. While this isn't the final diagram, as I'm still making adjustments in the process of developing this app, it lays the groundwork for the entity structure.

![image](https://github.com/jhonatanELC/SpareInventory/assets/160936645/56488ec0-5538-4841-b794-ce804eaf2763)
![image](https://github.com/jhonatanELC/SpareInventory/assets/160936645/a7643573-1bce-400a-b771-66a4caaa9dd3)


### **Which type of architecture to use?**

I decided to use clean architecture because it offers clear separation of concerns, which means that the core of my application will be decoupled from the Infrastructure and UI layers. This separation allows me to write the business logic once and use it with different presentation layers such as APIs, MVC, or React projects. By adopting clean architecture, I ensure that my application is modular, maintainable, and easily extensible in the future.

### **What about the views?**

Well, I'm not a designer, but I used to draw electrical plans in AutoCAD. I was going to use it, but then I heard about Figma, so I decided to try it out and make a simple sketch

![image](https://github.com/jhonatanELC/SpareInventory/assets/160936645/62fd0b8e-7771-4d9a-962d-40d624d15249)

## Getting Started
> This project hasn't been finished yet. It is still in development.

### 1. Clone the repository
There are two branches: master and MVC. The first is a web API, and the second is an MVC app.

```shell
git clone https://github.com/jhonatanELC/SpareInventory.git
cd SpareInventory
```

### 2. Set up the Database

- Go to **appsettings.json** 
  ```
    "ConnectionStrings": {
    "DefaultConnection": "Here type your connection string"
  }
  ```
- Run the Migrations
  ``` shell
  dotnet ef database update -s API -p Infrastructure
  ```

### 3. Run the app

```shell
dotnet run -p API
```

### 4. Open the app in your browser

Visit [http://localhost:7229](http://localhost:7229) in your browser.







