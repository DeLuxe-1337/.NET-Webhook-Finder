# .NET-Webhook-Finder
This finds all discord webhooks inside of a .net application.


This uses dnlib.

![image](https://user-images.githubusercontent.com/74394136/131579723-e68ac57a-87ba-42f1-b638-198f0c3789bc.png)

You can drag your exe onto the webhook finder and it will work or you can open it then type the path of the target!


------------ How it works ------------
1. Loop through all of the strings
2. See if the string contains the start of a discord webhook
3. Profit

------------ Todo list ---------------
- [ ] Better scanning
- [x] Basic scanning
- [ ] Base64 string scanning
- [ ] Encyrpted string scanning
- [ ] Auto string encryption solver 
