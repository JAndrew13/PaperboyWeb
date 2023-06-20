import { CreateOrders } from "./order";

export class Bot {
    id: string;
    name: string;
    description: string;
    status: string;
    exchange: string;
    tradingPair: string;
    createdDate: string;
    startingBalance: number;
    totalTrades: number;
    orders: any[];
  
    constructor(
      id: string,
      name: string,
      description: string,
      status: string,
      exchange: string,
      tradingPair: string,
      createdDate: string,
      startingBalance: number,
      totalTrades: number,
      orders: any[]
    ) {
      this.id = id;
      this.name = name;
      this.description = description;
      this.status = status;
      this.exchange = exchange;
      this.tradingPair = tradingPair;
      this.createdDate = createdDate;
      this.startingBalance = startingBalance;
      this.totalTrades = totalTrades;
      this.orders = orders;
    }
  }

  export function CreateBots(data: any): Bot[] {
    const botsData = data.bots;
    const bots: Bot[] = [];
  
    for (const botId in botsData) {
      const botData = botsData[botId];
      const orders = CreateOrders(botData);
      const totalTrades = orders.length;
      const bot = new Bot(
        botData.id,
        botData.name,
        botData.description,
        botData.status,
        botData.exchange,
        botData.tradingPair,
        botData.createdDate,
        botData.startingBalance,
        totalTrades,
        orders
      );
      
      bots.push(bot);
    }
  
    return bots;
}
  