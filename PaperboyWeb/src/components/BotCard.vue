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
                <v-chip class="text-overline font-weight-medium">Position - {{bot.orders[0].orderType}}</v-chip>
                <v-chip class="text-overline font-weight-medium">$ {{103.49}} USD</v-chip>
              </v-chip-group>
     
        </v-card-item>
      </v-card>
    </v-container>
  </template>
  
  <script lang  = "ts">
    import  {calcService}  from '../services/calculationService'
    export default {
    props: {
      bot: {
        type: Object,
        required: true
      }
    },
      computed: {
        botValue() {
          return 0
        },
        totalGainsLosses() {
          // calculate total gains/losses here
          return 0
        },
  },
      methods: {
        getDuration(createdDate: string) {
          return calcService.getDuration(createdDate) // you can use getDuration directly in your component now
      },
    }
  }
  </script>
  
  <style>
   
  </style>
  