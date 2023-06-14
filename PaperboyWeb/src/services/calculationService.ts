// calculationService.ts
import { Account } from "@/scripts/account";
import type { Order } from "@/scripts/order";
import apiService from '../services/apiService';
import { Token } from "@/scripts/token";


function getDuration(timeStamp: string): string {
    const now = new Date();
    const then = new Date(timeStamp);
    const diffInMilliseconds = now.getTime() - then.getTime();

    const diffInMinutes = Math.floor(diffInMilliseconds / (1000 * 60));
    const diffInHours = Math.floor(diffInMinutes / 60);
    const diffInDays = Math.floor(diffInHours / 24);

    const days = diffInDays;
    const hours = diffInHours % 24;
    const minutes = diffInMinutes % 60;

    return `${days}D  ${hours}Hr  ${minutes}Min`;
}




 async function percentChange(compareDate: string, orders: Order[]): Promise<number> {
  const compareDateTime = new Date(compareDate).getTime();

  const filteredOrders = orders.filter(order => new Date(order.timeStamp).getTime() >= compareDateTime);

  if (filteredOrders.length === 0) {
    throw new Error('No orders found within the compare date');
  }

  const oldestOrder = filteredOrders.reduce((prev, current) => 
    new Date(prev.timeStamp) < new Date(current.timeStamp) ? prev : current
  );

  const previousValue = oldestOrder.totalValue;
  const accountData = await apiService.GetAccountData();
    const currentValue = await getAccountValue();

  const percentChange = ((currentValue - (previousValue || 0)) / (previousValue || 1)) * 100;

  return percentChange;
}

 async function valueChange(compareDate: string, orders: Order[]): Promise<number> {
  const compareDateTime = new Date(compareDate).getTime();

  const filteredOrders = orders.filter(order => new Date(order.timeStamp).getTime() >= compareDateTime);

  if (filteredOrders.length === 0) {
    throw new Error('No orders found within the compare date');
  }

  const oldestOrder = filteredOrders.reduce((prev, current) => 
    new Date(prev.timeStamp) < new Date(current.timeStamp) ? prev : current
  );

  const previousValue = oldestOrder.totalValue;
  const accountData = await apiService.GetAccountData();
const currentValue = await getAccountValue();



  const valueChange = currentValue - (previousValue || 0);

  return valueChange;
}

 async function getTotalAccountsValue(accountData: Account[]): Promise<number> {
  let totalValue = 0;

  for (const account in accountData) {
    let accountValue = 0;
    const accountTokens = accountData[account].tokens
    // console.log("list of tokens in account : " + accountTokens) // lists only the symbol of the token
    for (const token in accountTokens) {  
      
      // console.log(token) // token name
      // console.log(accountTokens[token].getTotal()) // amount owned

      if (token !== "USDT" && token !=="USDC") {
        // its not a stable coin, -> fetch price
        const tokenPrice = await apiService.GetTokenPrice(`${token}-USDT`);
        accountValue += accountTokens[token].getTotal() * tokenPrice.lastPrice;
      }
    }
    totalValue += accountValue;
  }
  console.log(totalValue)
  return totalValue;
}
  





export const calcService = {
    getDuration,
      getTotalAccountsValue

















// Tasks include:
// ===== Object Initialization =====
// Build accounts from bot data - takes bot object as parameter


// ===== Tokens =====
// Get value of token amount in currency token - takes token1, token2, and amount as parameters

// ===== Accounts =====
// Get total value of account - takes account object as parameter

// ===== Orders =====
// Get total value of order - takes order object as parameter

// ===== Bot =====
// Get total value of bot - takes bot object as parameter
// Get total value of all bots - takes bot array as parameter
// Get total value of all bots in account - takes account object as parameter

// ===== Financial Data =====
// Get total value of all accounts - takes account array as parameter

}