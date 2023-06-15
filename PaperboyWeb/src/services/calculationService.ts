// calculationService.ts
import { Account } from "@/scripts/account";
import apiService from '../services/apiService';



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
      if (token === "USDC" || token === "USDT"){
        accountValue += accountTokens[token].getTotal()
      }
    }
    totalValue += accountValue;
  }
  console.log(totalValue)
  return totalValue;
}
  
 function getDateFormat(timeStamp: string): string{
    // format date to be used in the front end user display
    // incoming timestamp format = "2023-06-09T09:17:16.3972522"
    // format to "Fri, 09 Jun 2023 09:17:16 GMT"

    const date = new Date(timeStamp);
    const formattedDate = date.toUTCString();

    return formattedDate;
  }

export const calcService = {
    getDuration,
    getTotalAccountsValue,
    getDateFormat,
}