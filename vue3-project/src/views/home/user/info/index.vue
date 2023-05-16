<template>
  <el-card class="box-card">
    <el-table :data="tableData" style="width: 100%">
      <el-table-column prop="name" label="姓名" />
      <el-table-column prop="phone" label="手机号" />
      <el-table-column prop="address" label="地址" />
      <el-table-column prop="sex" label="性别">
        <template #default="{ row }">
          <el-tag :type="row.sex == 0 ? 'danger' : ''">
            {{ sexFilter(row.sex) }}
          </el-tag>
        </template>
      </el-table-column>
    </el-table>
  </el-card>
</template>

<script setup>
import { ref, onMounted, computed } from 'vue'
import axios from '@/api'  //导入axios

const tableData = ref([])  //表格的数据

onMounted(() => {
  userQuery
})

//性别文本格式化
const sexFilter = computed(() => item => {
  switch (item) {
    case 1:
      return '男'
    case 0:
      return '女'
    default:
      return '男'
  }
})

async function userQuery () {
  let { data } = await axios.get(`User/1/10`)
  let { data: d, success, message } = data
  if (success) {
    tableData.value = d.dataList //表格数据
  } else {
    alert(message)
  }
}

</script>