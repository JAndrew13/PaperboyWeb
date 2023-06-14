<template>
    <v-container pa-3 fluid>
      <v-card color="secondary">
        <v-toolbar color="teal-darken-2">
          <v-toolbar-title>
            <v-col class="mx-auto">
              <v-row class="text-h5 font-weight-bold"> {{bot.name}} </v-row>
              <v-row class="text-caption"> {{bot.description}} </v-row>
            </v-col>
          </v-toolbar-title>
       
          <span class="text-h5 font-weight-heavy mr-5"> {{bot.tradingPair}} </span>
          <!-- This will push the following elements to the right -->
        </v-toolbar>
        <v-card-item>
        
            <v-chip-group>
                <v-chip class="text-overline font-weight-medium">Orders  {{bot.totalTrades }} </v-chip>
                <v-chip class="text-overline font-weight-medium">Status - {{bot.status}} </v-chip>
                <v-chip class="text-overline font-weight-medium">Age - {{ getDuration(bot.createdDate) }}</v-chip>
                <v-chip class="text-overline font-weight-medium">Position - ordertype</v-chip>
                <v-chip class="text-overline font-weight-medium">$ {{103.49}} USD</v-chip>
                <v-chip>{{ tokenPrice }}</v-chip>
              </v-chip-group>
     
        </v-card-item>
      </v-card>
    </v-container>
  </template>
  
  <script lang  = "ts">
  import { ref, watch } from 'vue';
    import  {calcService}  from '../services/calculationService'
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
      computed: {
        botValue() {
          return 0
        },
        totalGainsLosses() {
          calcService.percentChange()
          return 0
        },
  },
      methods: {
        getDuration(createdDate: string) {
          return calcService.getDuration(createdDate) // you can use getDuration directly in your component now
      },
    },
    setup(props) {
    watch(() => props.tokenPrice, (newPrice, oldPrice) => {
      console.log(`Token price updated from ${oldPrice} to ${newPrice}`);
      // Do something with the updated price
    });
  }
  }
  </script>
  
  <style>
   
  </style>
  