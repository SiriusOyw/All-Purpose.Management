<template>
  <div class="module-box">
    <!-- 1行等5等分 -->
    <div class="box" :style="`flex: 0 1 ${100/lists.length}%;margin:5px;`" v-for="(v,i) in lists" :key="i">
      <div class="list-box">
         <i><el-icon><component  :is="v.icon" ></component></el-icon></i>
         <p>{{v.title}}</p>
      </div>
    </div>
  </div>

  <div class="module-box">
    <!-- 1行等2等分 -->
    <div style="flex: 0 1 30%;margin:5px;">
      <el-card class="box-card">
        <Chart 
        :title="'车辆库存'"
        :chartType="'bar'" 
        :chartData="[130,220,580,480,150,340,630,390]"
        :chartxAxis="['k924', 'g002', 'k878', 'a550', 'c635', 'a557', 'g080']"
        :color="'#2277ce'"/>
      </el-card>
    </div>
    <div style="flex: 0 1 70%;margin:5px;">
      <el-card class="box-card">
        <Chart 
        :title="'每天数据监测'"
        :chartType="'line'" 
        :chartData="[10,20,40,30,20,50,80,10,40,30,90]"
        :chartxAxis="['8:00', '9:00', '10:00', '11:00', '12:00', '13:00', '14:00', '15:00', '16:00', '17:00', '18:00']"
        :color="'#71c24a'"/>
      </el-card>
    </div>
  </div>

  <div class="module-box">
    <!-- 1行等1等分 -->
    <div style="flex: 0 1 100%;margin:5px;">
      <el-card class="box-card">
        <Chart 
        :title="'设备用电量'"
        :chartType="'line'" 
        :chartData="[1000,1100,800,780,850,1500,1670,1275,900,600,780,850,1100,1240]"
        :chartxAxis="['1月', '2月', '3月', '4月', '5月', '6月','7月', '8月', '9月', '10月', '11月', '12月']"
        :color="'#ea8052'"/>
      </el-card>
    </div>
  </div>
</template>



<script setup>
import { ref ,reactive} from 'vue'
import Chart from "./chart.vue"
import {
  ChromeFilled,
  Opportunity,
  SwitchFilled,
  TrendCharts,
  VideoCameraFilled
} from '@element-plus/icons-vue'

const lists = ref([
  {title:'电量监控',icon:ChromeFilled},
  {title:'车辆详情',icon:Opportunity},
  {title:'地图分布',icon:SwitchFilled},
  {title:'车辆监控',icon:TrendCharts},
  {title:'统计分析',icon:VideoCameraFilled}
])

</script>

<style scoped>

</style>
