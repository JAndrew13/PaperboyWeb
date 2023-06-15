<template>

   <v-img
          :src="bgImageDesktop"
          class="background"
          cover
        >
  <div>
    <NavBar @open-dialog="dialog = true" />
   
    <v-main>
    
      <v-container>
        <FinancialAnalysisTable :bots="bots" :accounts="accounts" @update-token-price="tokenPrice = $event" ></FinancialAnalysisTable>
      </v-container>
      <v-container>
        <v-row cols=" auto">
          <v-col cols="12" md="6" lg="4" v-for="bot in bots" :key="bot.id">
            <BotCard :bot="bot" :tokenPrice="tokenPrice"/>
          </v-col>
        </v-row>
      </v-container>

    </v-main>
  
    <BotCreationDialog v-model="dialog" />

 
  </div>


</v-img>

</template>

<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue';
import { Bot } from '@/scripts/bot';

import NavBar from '@/components/NavBar.vue';
import BotCard from '@/components/BotCard.vue';
import BotCreationDialog from '@/components/BotCreationDialog.vue';
import apiService from '@/services/apiService';
import FinancialAnalysisTable from '@/components/FinancialAnalysisTable.vue';
import { Account } from '@/scripts/account';
import bgImageDesktop from '@/assets/bg3.png'; // Import the desktop image

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
  console.log(response)
  bots.value = response;
};

onMounted(async () => { 
  // Fetch initially
  await fetchAccounts();
  await fetchBots();

  // Fetch every 5 seconds
  const intervalId = setInterval(async () => {
    await fetchAccounts();
    await fetchBots();
  }, 5000);

  // Clear the interval when the component is unmounted
  onUnmounted(() => {
    clearInterval(intervalId);
  });
});
</script>
<style scoped>
.background{
  background-color: aquamarine;
  background-size: cover; 
  background: 100% 100%; 

}
</style>