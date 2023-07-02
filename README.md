
<a name="readme-top"></a>
<div align="left">

  <h1>Paperboy Algo Trader</h1>
  
  <p>
    A simple algorithmic trading bot that uses Vue +Vuetify, C# API, and TradingView Webhooks to trade cryptocurrencies on a live marketplace
  </p>
   
<br />

<!-- About the Project -->
## :star2: About the Project

<br />
<p>
Paperboy, at its core, is essentially a middle-man for executing market trades, and has been a passion project of mine for quite some time now. The sole reason for creating this software started with a very simple, but constant problem - I suck at trading.. While I do my best to stay well informed, self aware, and thoughtful - I always fall into the same old fomo trap. No amount of YouTube tutorials or "Diamond Hands" would stop the constant bleed. I needed to take myself out of the equation.. I needed an unemotional, fearless, robot that never sleeps. With that realization, I got to work.

I needed to create something that wouldn't be a one-and-done type of solution. It needed to be flexible enough to jump between exchanges, strategies, and positions, as I learned new techniques while also containing a central hub for monitoring all my past trades, balances, and bots. I "central command" if you will.

Contained in this repository is the heart of Paperboy, a glorified excell spreadsheet with a snazzy web UI. 
</p>


<!-- Folder Structure -->
## :bangbang: Folder Structure

Here is the folder structure of 3D-Portfolio.

**Paperboy.Api/**
```bash  
┣ .vs/  
┣ bin/  
┣ Content/  
┣ Controllers/  
┣ Data/  
┣ Dtos/  
┣ Migrations/  
┣ obj/  
┣ Properties/  
┣ Services/  
┣ appsettings.Development.json  
┣ appsettings.json  
┣ Paperboy.Api.csproj  
┣ Paperboy.Api.sln  
┣ Program.cs  
┗ secrets.json
```
**PaperboyWeb/**  
```bash  
┣ .vscode/  
┣ dist/  
┣ node_modules/  
┣ public/  
┣ src/  
┣ .eslintrc.cjs  
┣ .gitignore  
┣ .prettierrc.json  
┣ env.d.ts  
┣ index.html  
┣ package-lock.json  
┣ package.json  
┣ README.md  
┣ tsconfig.app.json  
┣ tsconfig.json  
┣ tsconfig.node.json  
┣ tsconfig.vitest.json  
┣ vite.config.ts  
┗ vitest.config.ts
```
<br />

<!-- TechStack -->
### :space_invader: Tech Stack

![My Skills](https://skillicons.dev/icons?i=dotnet,azure,github,ts,vue)

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Getting Started -->
## :dart: Getting Started
### Prerequisites:
- VS Code
- Visual Studio
- SSMS
- Kucoin Account
- Trading View Account

<!-- Installation -->
### :gear: Installation

#### Step 1: Clone the repository
Download or clone this repo by using the link below:

```bash
 https://github.com/Jandrew13/PaperboyWeb
```

#### Step 2: External Accounts Setup
### Kucoin
1. If you don't have one already, go ahead and set up a KuCoin trading account and make sure you're verified. Its free, but it verification can sometimes take a few days. 

2. Send some stable-coin crypto to your account, like USDT or USDC. 

3. Generate your personal API key for paperboy, this gives paperboy access to your account for trading. 
	 - From your main dashboard, navigate to API Management -> Create API.
	 - Under the "API Based-Trading" tab, fill out the info for your new API.
	 - Create a **API Passphrase** for your api, and make sure to copy/paste this somewhere, you'll need this later.
	 - Under the Permission section, check the box for "Spot Trading".
	 - Under the IP Restriction, check the "NO" option (we don't want to restrict the IP address)
	 - When the **API Secret** is shown, make sure you save that as well.
4. Once you've created your Kucoin API, you should have the **Key, Secret, and Passphrase** saved somewhere. 

### Trading View
1. Head to Trading View and create an account. 
		 ** *note : I personally use a premium account here because it allows me to have 15 alerts running at a time. Each paperboy bot requires 2 alerts,  but I don't think you need a paid account to just have a single bot running. Its only $15/month though if you can spare the cash.*
		 
2. Navigate to the chart of your choice, my favorite is MATIC/USDT, and just make sure its one that is pulling data from the Kucoin Exchange. You'll know because in the chart search dropdown you should see a green Kucoin logo on the right.

3. Attach your trading algorithm to the chart.. 👇

***
**:warning: Important!**
Whether an Indicator or Strategy is used, remember this responsible for managing **all your money**, so if you're not comfortable with this, go ahead and add one from the community library of indicators

*** 
 #### Adding a Community Indicator 
While your chart is open, click the "indicators" button up at the top of the page, then select **community scripts**. From here, you can click to your hearts content!
		*tip*:  I recommend searching for the word "strategy" because it will pull up a list of community strategies, which are more in line with how paperboy functions. These scripts will contain lines of code that trigger buy and sell actions for trading and alerts. This is what you want. If you find an awesome script but it doesn't have these alert triggers set up, you'll have to add them manually.  
		

 #### Creating a Custom Indicator
Creating your own indicator is difficult, but its the best option if you can pull it off. 
At the bottom of your chart, you'll find the PineScript Editor. Here you can code to your heats content! the only real requirements for this to work with Paperboy is that somewhere in your algorithm you have a **Buy** and **Sell** trigger that **create an alert** when *something* happens.
 These triggers are what signal Paperboy to execute a trade on the exchange. What's really cool about PineScript is the built in **Strategy Tester** tab in the editor. In your editor's code, if you declare a *strategy* instead of *indicator*, then tab over to the strategy tester, Trading View will automatically back-test your algorithm on past market data and instantly display a full performance report for you. This is incredibly useful and should not be overlooked if you are creating your own algorithm. Additionally, be aware that different timeframes on your chart will produce different results, and your alerts are specific to that timeframe. Make sure that you dail all that in before creating your alerts. 
 
### Set up your Alerts
With the chart open and the indicator attached 
1.  Open the **Alert Manager** (*the alarm clock icon at the top of the page*) and create a new alert. 

2.  Take the JSON Text you got earlier from the bot creation page, and paste it into the "message" textbox.
 
3.  On the "Notifications" tab, select **Webhook**, and paste in your paperboy alerts address.
 
4.  Add any additional setup features or notifications your require, then hit save. 

5. Repeat this again for your other alert signal. In the end you should now have 2 alerts visible in your alert manager - one for your **Buy** signal, and another for your **Sell** signal.

#### Step 3:

At the main folder execute the following command in console to get the required dependencies:

```bash
  npm install
```

#### Step 4:

At the main folder execute the following command in console to creates a build directory with a production build of 3d portfolio:

```bash
  npm run build
```

#### Step 5:

At the main folder execute the following command in console to run the server:

```bash
  npm run start
```

<!-- Run Locally -->
### :running: Run Locally

#### Step 1:

At the main folder execute the following command in console to get the required dependencies:

```bash
  npm install
```

#### Step 2:

At the main folder execute the following command in console to run the development server:

```bash
  npm run dev
```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- License -->
## :warning: License

Distributed under the MIT License. See [LICENSE.txt](https://github.com/ladunjexa/Threejs_3D_Portfolio/blob/main/LICENSE) for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Contact -->
## :handshake: Contact

Jake Brunner - [linkedin](https://www.linkedin.com/in/jake-brunner-21760522b/) 

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Acknowledgments -->
## :gem: Acknowledgements


<p align="right">(<a href="#readme-top">back to top</a>)</p>

</p>
