export class Order {
    botId: string;
    alertId: string;
    id: string;
    txId: string | null;
    orderType: string;
    token1: string;
    token2: string;
    pair: string;
    status: string;
    tokenAmount: number;
    atPrice: number | null;
    totalValue: number | null;
    timeStamp: string;
  
    constructor(
      botId: string,
      alertId: string,
      id: string,
      txId: string | null,
      orderType: string,
      token1: string,
      token2: string,
      pair: string,
      status: string,
      tokenAmount: number,
      atPrice: number | null,
      totalValue: number | null,
      timeStamp: string
    ) {
      this.botId = botId;
      this.alertId = alertId;
      this.id = id;
      this.txId = txId;
      this.orderType = orderType;
      this.token1 = token1;
      this.token2 = token2;
      this.pair = pair;
      this.status = status;
      this.tokenAmount = tokenAmount;
      this.atPrice = atPrice;
      this.totalValue = totalValue;
      this.timeStamp = timeStamp;
    }
  }

  export function CreateOrders(botData: any): Order[] {
    const ordersData = botData.orders;
    const orders: Order[] = [];
  
    for (const orderId in ordersData) {
      const orderData = ordersData[orderId];
      const order = new Order(
        orderData.botId,
        orderData.alertId,
        orderData.id,
        orderData.txId,
        orderData.orderType,
        orderData.token1,
        orderData.token2,
        orderData.pair,
        orderData.status,
        orderData.tokenAmount,
        orderData.atPrice,
        orderData.totalValue,
        orderData.timeStamp
      );
      orders.push(order);
    }
  
    return orders;
    }