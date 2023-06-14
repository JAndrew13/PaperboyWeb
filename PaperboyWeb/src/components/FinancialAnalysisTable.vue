<template>
  <div class="financial-analysis-table">
    <v-sheet fluid class="mx-auto" variant="outlined" >
    <v-row cols="auto">

      <v-col cols="12" md="6" lg="4">
        <AccountValueCard :accounts="accounts" @update-token-price="$emit('update-token-price', $event)"></AccountValueCard>
      </v-col>

      <v-col cols="12" md="6" lg="4">
        <OverviewStatsCard :bots = "bots" :accounts="accounts"></OverviewStatsCard>
      </v-col>


     
    </v-row>
</v-sheet>
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