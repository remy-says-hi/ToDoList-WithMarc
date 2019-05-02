# _To Do List_

#### _Program which allows user to add items to a to do list and view their to do list, 04/24/2019_

#### By _**Marc Davies and Jared Farkas**_

## Description

_Program which allows user to add items to a to do list and view their to do list_

## Setup/Installation Requirements

* _Clone from GitHub_
* _$cd ToDoList.Solution/ToDoList_
* _$dotnet restore to install packages from the .csproj file_
* _$dotnet run to start the application_
* _Launch [http://localhost:5000/](http://localhost:5000/) in your browser_

## Specs

| Behavior | Input | Output |
| ------------- |:-------------:| -----:|
| 1. Upon launching the application, user has option to *Add a new item* or *View a to do list* | Launch application | ![Image of homepage](https://i.imgur.com/da8KI8G.png) |
| 2a. Upon clicking on *Add a new item*, user is presented with input field and an *Add* button | Click *Add a new item* | ![Image of additemscreen](https://i.imgur.com/LNIfJMp.png) |
| 2b. Upon clicking on  *View a to do list*, user is presented with list of to do items | Click  *View a to do list* | ![Image of listscreennoitem](https://i.imgur.com/rDCm0rB.png) |
| 3. Upon entering an item and clicking on the *Add* button, user is directed to the list of to do items | Enter to do item and click *Add* | ![Image of listscreenitem](https://i.imgur.com/LtFnxkj.png) |
| 4. User then has option to *Add a new item*, *Clear all items* or click on an item | After clicking *Add* during step 3. | ![Image of listscreenitem](https://i.imgur.com/LtFnxkj.png) |
| 5a. Upon clicking on *Add a new item*, user is presented with input field and an *Add* button | Click *Add a new item* | ![Image of additemscreen](https://i.imgur.com/LNIfJMp.png) |
| 5b. Upon clicking on *Clear all items*, user is directed to the now empty list of to do items | Click *Clear all items* | ![Image of listcleared](https://i.imgur.com/kBwqow2.png) |
| 5c. Upon clicking on an item, user is directed to a detailed description of the to do item | Click on an item | ![Image of itemdetails](https://i.imgur.com/xJI4NuZ.png) |
| 6. User then has option to *Add another item* or *View all items* | After clicking on item during step 5c. | ![Image of itemdetails](https://i.imgur.com/xJI4NuZ.png) |
| 7a. Upon clicking on *Add another item*, user is presented with input field and an *Add* button (see 2a.) | Click *Add a new item* | ![Image of additemscreen](https://i.imgur.com/LNIfJMp.png) |
| 7b. Upon clicking on  *View all items*, user is redirected to the list of to do items (see 2b.) | Click *View a to do list* | ![Image of listscreenitem](https://i.imgur.com/LtFnxkj.png) |
| 8. After clearing all items (see step 5b.), user can go back to the now empty list by clicking on *Back to list* | Click *Back to list* | ![Image of listscreennoitem](https://i.imgur.com/rDCm0rB.png) |

## Known Bugs

_When adding an item to a category, an error message will appear. The item does get added though._

## Support and contact details

_Please contact me at marcdaviesriot@gmail.com if you run into any issues or have questions, ideas or feedback._

## Technologies Used

_C#_

### License

*This software is licensed under the GPL license.*

Copyright (c) 2019 **_Marc Davies and Jared Farkas_**
