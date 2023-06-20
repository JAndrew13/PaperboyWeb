<template>
  <div class="financial-analysis-table">
    <v-card fluid pa-3 class="mx-auto" color="secondary" width="350" >
      <v-col  auto>
        <AccountValueCard :accounts="accounts" @update-token-price="$emit('update-token-price', $event)" color="primary"></AccountValueCard>
      
        <OverviewStatsCard :bots = "bots" :accounts="accounts" class="secondary--text"></OverviewStatsCard>
      </v-col>
    </v-card>
  </div>
</template>
  
  <script lang="ts">
  import { defineComponent, type PropType } from 'vue';
  import { Account } from '@/scripts/account';
  import { Bot } from '@/scripts/bot';
  import AccountValueCard from '@/components/AccountValueCard.vue';
  import OverviewStatsCard from '@/components/OverviewStatsCard.vue';


  export default defineComponent({
    name: "FinancialAnalysisTable",
    props: {
        accounts: {
          type: Array as PropType<Account[]>,
          required: true,
        }, 
        bots: {
          type: Array as PropType<Bot[]>,
          required: true,
        }

    },
    components: { AccountValueCard, OverviewStatsCard }
});


  </script>