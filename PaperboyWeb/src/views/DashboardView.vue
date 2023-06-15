<template>
  <div class="dashboard">
    <NavBar @open-dialog="dialog = true" />
    <v-main>
      <v-container>
        <FinancialAnalysisTable :bots="bots" :accounts="accounts" @update-token-price="tokenPrice = $event" ></FinancialAnalysisTable>
      </v-container>
      <v-divider color="purp"></v-divider>
      <v-container>
        <v-row cols=" auto">
          <v-col cols="12" md="6" lg="4" v-for="bot in bots" :key="bot.id">
            <BotCard1 :bot="bot" :tokenPrice="tokenPrice"/>
          </v-col>
        </v-row>
      </v-container>
    </v-main>
    <BotCreationDialog v-model="dialog" />
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { Bot } from '@/scripts/bot';

import NavBar from '@/components/NavBar.vue';
import BotCard1 from '@/components/BotCard.vue';
import BotCreationDialog from '@/components/BotCreationDialog.vue';
import apiService from '@/services/apiService';
import FinancialAnalysisTable from '@/components/FinancialAnalysisTable.vue';
import { Account } from '@/scripts/account';


const accounts = ref<Account[]>([]);
const bots = ref<Bot[]>([]);
const tokenPrice = ref(0);
const dialog = ref(false);

const fetchAccounts = async () => {
  const response = await apiService.GetAccountData();
  accounts.value = response;
};

const fetchBots = async () => {
  let response = await apiService.GetBots(); 
  bots.value = response;
};

onMounted(async () => { 
  await fetchAccounts();
  await fetchBots();
});

</script>
<style scoped>
.dashboard {
  background-color: aquamarine;
  background-image: url(@/assets/bg3.png);
  background-size: cover;

}
</style>