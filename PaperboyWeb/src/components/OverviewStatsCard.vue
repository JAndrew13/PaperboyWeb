<template>


<v-card max-width="350">
  <v-card-item>
    <v-table density="compact">
    <thead>
      <tr>
        <th>
          <v-spacer></v-spacer>
        </th>
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
        <td class="font-weight-bold pa-0">{{ "P/L" }}</td>
        <td class="font-weight-bold pa-0">+{{ item.Day }}%</td>
        <td class="font-weight-bold pa-0">+{{ item.Week }}%</td>
        <td class="font-weight-bold pa-0">+{{ item.Month }}%</td>
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
import { calcService } from '@/services/calculationService';

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