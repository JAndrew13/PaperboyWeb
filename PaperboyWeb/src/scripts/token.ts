export class Token {
    id: string;
    asset: string;
    type: number;
    total: number;
    available: number;
    holds: number;
  
    constructor(id: string, asset: string, type: number, total: number, available: number, holds: number) {
      this.id = id;
      this.asset = asset;
      this.type = type;
      this.total = total;
      this.available = available;
      this.holds = holds;
    }

    getAsset() {
        return this.asset
    }

    getType() {
        return this.type
    }

    getTotal() {
        return this.total
    }
  }