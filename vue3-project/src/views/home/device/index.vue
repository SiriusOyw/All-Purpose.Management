<template>
   <div>
     <router-view />
   </div>
</template>

<script setup>
import {ref} from 'vue'

const title = ref('设备监控')

</script>