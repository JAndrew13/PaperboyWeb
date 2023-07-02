
<a name="readme-top"></a>


   # 💸Paperboy Algo Trader
  

 A simple algorithmic trading bot that uses Vue +Vuetify, C# API, and TradingView Webhooks to trade cryptocurrencies on a live marketplace

   
<br />

<!-- About the Project -->
## :star2: About the Project

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
## :gear: Installation and Setup

#### Step 1: Clone the repository
Download or clone this repo by using the link below:

```bash
 https://github.com/Jandrew13/PaperboyWeb
```
#### Step 2: The Backend
1. Inside Visual Studio, select "Open Project or Solution" and select the *Paperboy.Api.snl* file inside the 
`Paperboy/Paperboy.Api/` folder.

2. Once you've got this open, create a new file in the root directory called **secrets.json**
3. Open that file and paste in the following, (you'll fill in the specific details later.)
```
{
  "Secrets": {
    "Key": "YourApiKey",
    "Secret": "YourApiSecret",
    "Passphrase": "YourApiPassphrase"
  }
}
```

#### Step 3: Kucoin Setup
1. If you don't have one already, go ahead and set up a KuCoin trading account and make sure you're verified. Its free, but it verification can sometimes take a few days. 

2. Send some stable-coin crypto to your account, like USDT or USDC. 

3. Generate your personal API key for paperboy, this gives paperboy access to your account for trading. 
	 - From your main dashboard, navigate to API Management -> Create API.
	 - Under the "API Based-Trading" tab, fill out the info for your new API.
	 - Create a **API Passphrase** for your api, and make sure to copy/paste this somewhere, you'll need this later.
	 - Under the Permission section, check the box for "Spot Trading".
	 - Under the IP Restriction, check the "NO" option (we don't want to restrict the IP address)
	 - When the **API Secret** is shown, make sure you save that as well.
4. Once you've created your Kucoin API, you should have a **Key, Secret, and Passphrase**, go ahead and insert these details into the *secrets.json* file you created earlier and hit **Save**

5. Hit the green play button in Visual Studio to build the project and run the backend. If all is well, then in you should see a web browser open to the Swagger Paperboy dashboard. Great job! Now for the brains of the operation.. 

#### Step 4: Trading View
1. Head to Trading View and create an account. 
		 ** *note : I personally use a premium account here because it allows me to have 15 alerts running at a time. Each paperboy bot requires 2 alerts,  but I don't think you need a paid account to just have a single bot running. Its only $15/month though if you can spare the cash.*
		 
2. Currently, Paperboy is only set up to support trading with the pair MATIC/USDT. Full token support is coming ASAP. Until the, use this chart. Just make sure its the MATIC/USDT chart that is pulling data from the Kucoin Exchange. You'll know because in the chart search dropdown you should see a green Kucoin logo on the right.

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
First thing that we need to do is setup the JSON data for our bot. This data is what gets sent to paperboy from Trading View when its time to buy/sell.
1. Open the Swagger page that popped up earlier when we ran the backend.
2. Scroll down to the bottom and you should see a blue dropdown called **GET Report** under the Report Section, Click it.
3. Press the **Try it out** button, and then press **Execute**
4. Youll see a bunch of information returned below, all we need from this is the **Bot ID**. It should be at the top of that data, and will look something like this:
`
5813f775-4f16-47f7-8f0b-790d5a36d8fe
`
5. Copy that botID and head back over to your Trading View chart

With the chart open and the indicator attached..
1.  Open the **Alert Manager** (*the alarm clock icon at the top of the page*) and create a new alert. 
2.  In the alert popup, you'll see a text field called **messages**, paste the following code into that box with your bot id. 
```
{
  "action": "BUY",
  "ticker1": "MATIC",
  "ticker2": "USDT",
  "botId": "YourBotId"
}
```

3.  On the "Notifications" tab, select **Webhook**, and paste in your paperboy alerts address.
4.  Add any additional setup features or notifications your require, then hit save. 
5. Repeat this again for your other alert signal, but change *BUY* to *SELL* where relevant.   In the end you should now have 2 alerts visible in your alert manager - one for your indicators **Buy** signal, and another for your indicators **Sell** signal.

#### Step 4: Fire up that UI :fire::fire::fire:

Finally, Open up the **Paperboy.Web** folder inside VS code and run the following commands from the VS terminal.
```bash
  npm i
```
```bash
  npm run dev
```

Once the process is complete, you should see a link displayed in the terminal. Click the link or copy/paste it into your browser to head over to the Website.

### annnd.. you're live! ::

## Using the Website
From the main landing page, head over to the **Dashboard** tab. Here you should see the bot you created displayed, along with a few basic controls and order data. Assuming you have the correct funds in your Kucoin account - you should be able to test the bots connection by pressing the `Force Buy` and `Force Sell` buttons. This will execute a live trade on the market and should only be used when..

- You are running setup or testing
- The Fomo is too great
- The algo you created is :poop:
- your showing off to your homies
- Your too lazy to MFA login to your kucoin account

## Conclusion
This project is still very much a work in progress and should be used with caution. There's probably a few bugs, and certain parts of the Web UI are still in development. I will be going into much further detail on how to use Paperboy effectively, how to build algos, and how to create bot teams once I get a more solid version out. There is much work left to do! 

Before you get started on the crazy PineScript rabbit-hole your about to go on.. 
please take a second to read the following disclaimers.
 
:sparkle: The Paperboy team is **NOT** responsible if  you lose money or if your bots make bad trades.:sparkle:

:warning: **Don't give** your life savings to Paperboy
:warning: Money cannot leave your account via paperboy unless you authorize transfers when you created the api.  
:warning: **Do not** authorize transfers when you create your Kucoin API, If you need to cash out, do it manually!
:warning: This is whole project is about having robots make choices with your money, its inherently risky.
:warning: Regarding custom algos - If you build it, build it right.

:sparkle: The Paperboy team is **NOT** responsible if  you lose money or if your bots make bad trades.:sparkle:

With that 


<!-- License -->
## :warning: License

Distributed under the MIT License. See [LICENSE.txt](https://github.com/ladunjexa/Threejs_3D_Portfolio/blob/main/LICENSE) for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Contact -->
## :handshake: Contact

Jake Brunner (Creator) - [linkedin](https://www.linkedin.com/in/jake-brunner-21760522b/) 

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- Acknowledgments -->



<p align="right">(<a href="#readme-top">back to top</a>)</p>

</p>
