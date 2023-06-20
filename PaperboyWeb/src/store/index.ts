import { createStore } from "vuex";

export default createStore({
  state: {
    bots: [],
    financialData: [],
  },
  mutations: {
    setBots(state, bots) {
      state.bots = bots;
    },
    setFinancialData(state, data) {
      state.financialData = data;
    },
  },
  actions: {
    fetchBots({ commit }) {
      // Logic to fetch bots from the API and commit the 'setBots' mutation
    },
    fetchFinancialData({ commit }) {
      // Logic to fetch financial data from the API and commit the 'setFinancialData' mutation
    },
  },
});
