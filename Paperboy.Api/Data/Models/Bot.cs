﻿namespace Paperboy.Api.Data.Models
{
    public class Bot
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Paperboy";
        public string Description { get; set; } = "A Simple Trading Bot";
        public string Status { get; set; } = "Active";
        public string Exchange { get; set; } = "KuCoin";
        public string TradingPair { get; set; } = "MATIC-USDT";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public TimeSpan TimeRunning { get; set; } = TimeSpan.Zero;
        public double StartingBalance { get; set; } = 0;
        public double CurrentBalance { get; set; } = 0;
        public double ProfitLoss { get; set; } = 0;
        public double ProfitLossPercent { get; set; } = 0;
        public int TotalTrades { get; set; } = 0;

    }
}