<template>
  <div>
    <v-app-bar app color="teal-darken-3">
      <v-toolbar-title>Dashboard</v-toolbar-title>
    </v-app-bar>
    <v-main>
      <v-container>
        <!-- <v-btn @click="fetchAccounts">Fetch Accounts</v-btn> -->
        <FinancialAnalysisTable :bots="bots" :accounts="accounts" @update-token-price="tokenPrice = $event" ></FinancialAnalysisTable>
      </v-container>
      <v-divider></v-divider>
      <v-container>
        <v-row cols=" auto">
          <v-col cols="12" md="6" lg="4" v-for="bot in bots" :key="bot.id">
            <BotCard1 :bot="bot" :tokenPrice="tokenPrice"/>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted} from 'vue';
import { Bot } from '@/scripts/bot';

import BotCard1 from '@/components/BotCard.vue';
import apiService from '@/services/apiService';
import FinancialAnalysisTable from '@/components/FinancialAnalysisTable.vue';
import { Account } from '@/scripts/account';

const accounts = ref<Account[]>([]);
const bots = ref<Bot[]>([]);
const tokenPrice = ref(0);

const fetchAccounts = async () => {
  const response = await apiService.GetAccountData();
  accounts.value = response;
};

const fetchBots = async () => {
  let response = await apiService.GetBots(); // replace with your actual API call
  bots.value = response;
};

onMounted(async () => { 
  await fetchAccounts();
  await fetchBots();
});

</script>
