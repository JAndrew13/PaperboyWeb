import axios from 'axios';
import { CreateBots } from '@/scripts/bot';
import { CreateAccounts } from '@/scripts/account';
import { BotDto } from '@/scripts/botDto';
import { mdiConsoleLine } from '@mdi/js';



// use sample data for now

const apiClient = axios.create({
  baseURL: 'https://localhost:7053',
  withCredentials: false, // This is the default
  headers: {
    Accept: 'application/json',
    'Content-Type': 'application/json',
  },
});

export default {

  //  ==== Object Creation / Data Retrieval ==== //

  async GetBots(botId?: string) {
    let endpoint = '/api/Report/BotReport';
    if (botId) {
      endpoint += `?botId=${botId}`;
    }
    const response = await apiClient.get(endpoint);
    const report = await CreateBots(response.data);

    return report
  },

  async CreateNewBot(
    name: string, 
    description: string, 
    token1: string, 
    token2: string) {

    const responseCreate = await apiClient.post('/api/Bot/Create');
    const bot = responseCreate.data;
    const botDto = new BotDto(
        bot.id,
        name,
        description,
        "active",
        "kucoin",
        `${token1.toUpperCase()}-${token2.toUpperCase()}`,
        bot.CreatedDate,
        0,
        0
    );

    await apiClient.patch('api/Bot/Update/', botDto);
      

    const webhook = {
        "action": "string",
        "ticker1": token1.toUpperCase(),
        "ticker2": token2.toUpperCase(),
        "botId": bot.id.toString()
    };
    // return the webhook
    return webhook;
},


  async GetAccountData() {
    const response = await apiClient.get('/api/Account/Accounts');
    return CreateAccounts(response.data);
  },

  async GetTokenPrice(tokenPair: string) {
    const response = await apiClient.get(`/api/Account/GetTokenPrice?pair=${tokenPair}`);
    return response.data;
  },

  async ForceSell(botId: string) {
    const data = {
        "action": "SELL",
        "ticker1": "MATIC",
        "ticker2": "USDT",
        "botId": botId
    };
    const response = await apiClient.post(`/api/Alerts`, data);
    console.log(response)
    return response.data;
},

async ForceBuy(botId: string) {
    const data = {
        "action": "BUY",
        "ticker1": "MATIC",
        "ticker2": "USDT",
        "botId": botId
    };
    const response = await apiClient.post(`/api/Alerts`, data);
    console.log(response)
    return response.data;
}
};

