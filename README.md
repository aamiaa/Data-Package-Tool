# Data Package Tool
A tool focused on browsing the actual contents of a Discord data package.

Note: This is my first C# app, sorry for bad code or development mistakes

[Download the latest release](https://github.com/aamiaa/Data-Package-Tool/releases)

## Features
- Search your messages
- Jump to messages in your client
- Mass delete messages*
- Reopen lost DMs*
- Browse all images you've sent
- View all servers you've joined, along with invites you've used
- View all DMs you've talked in

\* Requires your account token. Note that this falls under selfbotting, which is against Discord's [Community Guidelines](https://discord.com/guidelines#:~:text=Do%20not%20use%20self%2Dbots%20or%20user%2Dbots) and might get your account banned. 

## Screenshots
![image](https://i.imgur.com/kPnrtgs.png)

![image](https://i.imgur.com/glSJuQa.png)

![image](https://i.imgur.com/odXKiNr.png)


## Benchmark
These were done on my machine:tm: so they might not be accurate

| # of messages | Load time  | RAM usage |
|---------------|------------|-----------|
| 1.2mil        | 21s        | 412mb     |
| 1mil          | 18s        | 403mb     |
| 941k          | 16s        | 346mb     |
| 803k          | 14s        | 318mb     |
| 641k          | 11s        | 250mb     |
| 243k          | 5s         | 114mb     |
| 47k           | 2s         | 50mb      |