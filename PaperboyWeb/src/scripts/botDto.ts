export class BotDto {
    id: string;
    name?: string;
    description?: string;
    status?: string;
    exchange?: string;
    tradingPair?: string;
    createdDate?: string;
    startingBalance?: number;
    totalTrades?: number;
    orders?: any[];

    constructor(
        id: string,
        name?: string,
        description?: string,
        status?: string,
        exchange?: string,
        tradingPair?: string,
        createdDate?: string,
        startingBalance?: number,
        totalTrades?: number,
        orders?: any[]
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
