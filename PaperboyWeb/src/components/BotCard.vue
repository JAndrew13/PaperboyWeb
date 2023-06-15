<template>
    <v-container pa-3 fluid>
      <v-card color="secondary">
        <v-toolbar color="primary">
          <v-toolbar-title>
            <v-col class="mx-auto">
              <v-row class="text-h5 font-weight-bold mt-1"> {{bot.name}} </v-row>
              <v-row class="text-overline mb-0"> {{bot.description}} </v-row>
            </v-col>
          </v-toolbar-title>
       
          <span class="text-h5 font-weight-heavy mr-5"> {{bot.tradingPair}} </span>
          
        </v-toolbar>
        <v-card-item>
            <v-chip-group>
                <v-chip class="text-overline font-weight-medium">Total Orders  {{bot.totalTrades }} </v-chip>
                <v-chip class="text-overline font-weight-medium">Status - {{bot.status}} </v-chip>
                <v-chip class="text-overline font-weight-medium">Age - {{ getDuration(bot.createdDate) }}</v-chip>
                <v-chip class="text-overline font-weight-medium">Est. P/L - {{ - bot.startingBalance }}</v-chip>
              </v-chip-group>
        </v-card-item>
        <v-card-item>
          <v-container>
          <v-row>
          <v-btn @click="forceBuy(bot.id)" density="compact" color="green mr-2">Force Buy</v-btn>
          <v-btn @click="forceSell(bot.id)" density="compact" color="red ml-2">Force Sell</v-btn>
        </v-row>
      </v-container>
        </v-card-item>
      
        <v-card-item>
          <v-expansion-panels class="mb-6" color="primary">
            <v-expansion-panel color="primary"
              v-for="order in (bot.orders)" :key="order" class="mb-2">
              <v-expansion-panel-title expand-icon="mdi-menu-down" color="accent" >
                  <v-row cols="auto" >
                  <div class="mx-2">
                    <v-btn :color="order.orderType === 'SELL' ? 'red-lighten-3' : 'green-lighten-3'" size="small">{{ order.orderType }}</v-btn>
                  </div>
                  <div class="text-overline dark-text" >
                    
                      {{ order.tokenAmount}} {{ order.token1 }} 
                    
                  </div>
                    <v-spacer></v-spacer>
                    <div class="text-overline dark-text" >
                        @ {{ order.atPrice }} Each
                    </div>
                    <v-spacer></v-spacer>
                  </v-row>
              </v-expansion-panel-title>
              <v-expansion-panel-text color="accent">
                
                <v-table>
                  <thead>
                    <tr>
                      <th class="text-left text-overline dark-text">Status</th>
                      <th class="text-left text-overline dark-text">Date</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr>
                      <td class="text-left text-overline dark-text">{{ order.status }}</td>
                      <td class="text-left text-overline dark-text">{{getDateFormat(order.timeStamp)}}</td>
                    </tr>
                  </tbody>
                </v-table>
              </v-expansion-panel-text>
            </v-expansion-panel>
          </v-expansion-panels>
        </v-card-item>
      </v-card>
    </v-container>
  </template>
  
  <script lang  = "ts">
    import { watch } from 'vue';
    import  {calcService}  from '../services/calculationService'
import apiService from '@/services/apiService';


    export default {
    props: {
      bot: {
        type: Object,
        required: true
      },
      tokenPrice: {
      type: Number,
      required: true
      }
  },
      methods: {
        getDuration(createdDate: string) {
          return calcService.getDuration(createdDate) 
        },
        getDateFormat(timeStamp: string) {
          return calcService.getDateFormat(timeStamp)
        },
        forceBuy(id: string) {
          apiService.ForceBuy(id);
        },
        forceSell(id: string) {
          apiService.ForceSell(id);
        }
        
    },
    
    setup(props) {
      watch(() => props.tokenPrice, (newPrice, oldPrice) => {
      console.log(`Token price updated from ${oldPrice} to ${newPrice}`);
      
      
    });
  }
  }
  </script>
<style scoped>
.dark-text {
  color: darkslategray !important;
}
</style>