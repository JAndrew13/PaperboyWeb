<template>


<v-card >
  <v-card-item class="accent">
    <v-table  density="compact" class="accent">
    <thead >
      <tr>
       
        <th class="text-overline pa-0">Day</th>
        <th class="text-overline pa-0">Week</th>
        <th class="text-overline pa-0">Month</th>
      </tr>
    </thead>
    <tbody>
      <tr
        v-for="item in TimeFrames"
        :key="item.name"
      >
        <td class="font-weight-bold pa-0 dark-text">+{{ item.Day }}%</td>
        <td class="font-weight-bold pa-0 dark-text">+{{ item.Week }}%</td>
        <td class="font-weight-bold pa-0 dark-text">+{{ item.Month }}%</td>
      </tr>
    </tbody>

  </v-table>
</v-card-item>
</v-card>
</template>

<script lang="ts">
import { Bot } from '@/scripts/bot';
import { Account } from '@/scripts/account';
import { type PropType } from 'vue';


export default {
  name: 'OverviewStatsCard',
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
  methods: {
    getPL() {
      
    }
  },
  data () {
    return {
      TimeFrames: [
        {
          name: 'MATIC',
          Day: 2,
          Week: 3,
          Month: 4,
        },
    ],
  }
}, 

}
</script>

<style scoped>
.accent {
  background-color: #F2EBBF;

}

.dark-text {
  color: darkslategray !important;
}
</style>
```