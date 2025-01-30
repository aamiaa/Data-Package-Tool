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

## Usage Guide
You can find various guides and examples under the wiki tab:
- [Getting your package](https://github.com/aamiaa/Data-Package-Tool/wiki/Getting-your-package)
- [Reopening a lost DM](https://github.com/aamiaa/Data-Package-Tool/wiki/Reopening-a-lost-DM)
- [Searching in a specific server/channel/dm](https://github.com/aamiaa/Data-Package-Tool/wiki/Searching-in-a-specific-server-channel-dm)

## Your Data Safety
Not trusting a random program with your data package is completely understandable. For this reason, I've ensured the following to make it as comfortable as possible to use this tool:
- **It works fully offline**. You can unplug your internet or run it in an isolated vm, and it will still work the same, minus the features which require internet connection (e.g. viewing images, reopening dms).
- **It doesn't contact any unreputable 3rd party apis**. The only domains it might contact are `discord.com`, `cdn.discordapp.com`, `raw.githubusercontent.com` (to check for updates, which you can disable), and `versionhistory.googleapis.com` (to get latest Chrome version for selfbot headers).
- **It's built directly from the source by GitHub Actions**. This ensures that the .exe you're downloading only contains the code that's in this repo. You can verify that a release's file hasn't been swapped/modified by downloading the same version from [GitHub Actions](https://github.com/aamiaa/Data-Package-Tool/actions/workflows/release.yml) artifacts, and comparing both .exe files.

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
