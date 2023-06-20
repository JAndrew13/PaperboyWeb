import { ref } from 'vue'
import apiService from '@/services/apiService'
import { calcService } from '@/services/calculationService'

// Global const accountValue
const accountValue = ref("0")

export default function useAccountValue() {
  const refreshAccountValue = async () => {
    const response = await apiService.GetAccountData()
    const  x = await calcService.getTotalAccountsValue(response)
    console.log(x)
    
    accountValue.value = x.toPrecision(4)
  }

  return {
    accountValue,
    refreshAccountValue,
  }
}