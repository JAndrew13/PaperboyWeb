import axios from 'axios';
import { CreateBots } from '@/scripts/bot';
import { CreateAccounts } from '@/scripts/account';


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
    console.log(report)
    return report
    },

  async GetAccountData() {
    const response = await apiClient.get('/api/Account/Accounts');
    return CreateAccounts(response.data);
  },

  async GetTokenPrice(tokenPair: string) {
    const response = await apiClient.get(`/api/Account/GetTokenPrice?pair=${tokenPair}`);
    return response.data.lastPrice;
  },
//   // ==== Object Manipulation ==== // 

//   async CreateBot() {
//     // TODO:   Return bot Id neatly
//     return apiClient.post('/api/Bot/Create'); // Replace with your actual endpoint
//   },

//  async  UpdateBot() {
//   // TODO:  Take bot id as parameter, return bot  with new data
//     return apiClient.put('/api/Bot/Update'); // Replace with your actual endpoint
//   },

//   async DeleteBot() {
//     // TODO:   take bot parameter, return Ok or Error
//     return apiClient.delete('/api/Bot/Delete'); // Replace with your actual endpoint
//   },

//   async GetTokenData() {
//     //TODO:  take token symbol as parameter, return token data
// }
}
