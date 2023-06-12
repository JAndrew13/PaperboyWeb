// calculationService.ts

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

// Add more calculation functions as needed...

export const calcService = {
    getDuration,
















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