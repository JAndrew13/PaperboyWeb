import { Token } from './token';

export class Account {
  name: string;
  id: number;
  tokens: Token[];

  constructor(name: string, id: number, tokens: Token[]) {
    this.name = name;
    this.id = id;
    this.tokens = tokens;
  }

  getTokens() {
    return this.tokens
  }
}

export function CreateAccounts(data: any[]): Account[] {
  const accountsMap: { [key: number]: Account } = {};

  data.forEach(item => {
    const token = new Token(item.id, item.asset, item.type, item.total, item.available, item.holds); 

    if (!accountsMap[item.type]) {
      const account = new Account("", item.type, []);
      accountsMap[item.type] = account;
    }
    accountsMap[item.type].tokens[item.asset] = token;
  });
  return Object.values(accountsMap);
}