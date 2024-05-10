# Spare parts Inventory <img src="https://github.com/jhonatanELC/SpareInventory/assets/160936645/ebb70a38-e554-4ee4-90aa-e072e4c0c546" alt="image" width="60" height="60" align="middle"> 

## Introduction
Hello and welcome to my first ambitious project! You might be wondering, what exactly is this project? Well, it's an inventory system for spare parts. While this might sound boring to some, for me, it's incredibly exciting.

## Table of Contents
- [Introduction](#introduction)
- [Why an inventory app, you ask?](#why-an-inventory-app-you-ask)
- [Which technology to use?](#which-technology-to-use)
- [Which type of web app must I choose?](#which-type-of-web-app-must-i-choose)
- [Which are my entities?](#which-are-my-entities)
- [Which type of architecture to use?](#which-type-of-architecture-to-use)

### **Why an inventory app, you ask?**

Let me take you back a few years. I used to work as a mechanic, but then I transitioned to the spare parts sales department. Back then, everything was managed using paper registers. Seeing the need for a change, I decided to incorporate Excel into our system. Now that you understand my motivation, let me guide you through my thoughts:

### **Which technology to use?**

I'm a big fan of C# and its entire ecosystem.

### **Which type of web app must I choose?**

First, a web API, then an MVC app, and finally, I will use React.

### **Which are my entities?**

Well, it all starts with the UML class diagram. It took me many hours to figure out the best option that fulfills my requirements. While this isn't the final diagram, as I'm still making adjustments in the process of developing this app, it lays the groundwork for the entity structure.
![image](https://github.com/jhonatanELC/SpareInventory/assets/160936645/56488ec0-5538-4841-b794-ce804eaf2763)
![image](https://github.com/jhonatanELC/SpareInventory/assets/160936645/a7643573-1bce-400a-b771-66a4caaa9dd3)


### **Which type of architecture to use?**

I decided to use clean architecture because it offers clear separation of concerns, which means that the core of my application will be decoupled from the Infrastructure and UI layers. This separation allows me to write the business logic once and use it with different presentation layers such as APIs, MVC, or React projects. By adopting clean architecture, I ensure that my application is modular, maintainable, and easily extensible in the future.



