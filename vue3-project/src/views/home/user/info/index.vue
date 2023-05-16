<template>
   <el-card class="box-card">
      <el-table :data="tableData" style="width: 100%">
         <el-table-column prop="name" label="姓名"  />
         <el-table-column prop="phone" label="手机号"  />
         <el-table-column prop="address" label="地址" />
         <el-table-column prop="sex" label="性别" >
            <template #default="{row}">
               <el-tag :type="row.sex==0?'':'danger'">
                  {{sexFilter(row.sex)}}
               </el-tag>
            </template>
         </el-table-column>
      </el-table>

      <!-- 分页 -->
      <div class="pagination">
         <el-pagination 
            background 
            layout="prev, pager, next ,sizes" 
            :page-sizes="[10, 20, 30, 40]"
            :total="rows" 
             @size-change="handleSizeChange"
             @current-change="handleCurrentChange"
            />
      </div>
   </el-card>
</template>

<script setup>
import {ref,reactive,onMounted,computed} from 'vue'
import axios from '@/api'  //导入axios

const tableData = ref([]); //表格的数据
let rows = ref(1); //总数
const listQuery = reactive({
   pageindex:1,
   pageSize:10,
   name:''
})
onMounted(()=>{
   userQuery()
})
//性别文本格式化
const sexFilter = computed(()=>item=>{
   switch(item){
      case 0:
         return "男"
      case 1:
         return "女"
      default:
         return "男"
   }
})

async function userQuery(){
   let {data} = await axios.get(`User/${listQuery.pageindex}/${listQuery.pageSize}`);
   let {data:d,success,message} = data;
   if(success){
      tableData.value = d.dataList; //表格数据
      rows.value = d.recordCount;  //总数
   }else {
      alert(message)
   }
   
}

const handleSizeChange = (val) => {
  console.log(`${val} items per page`)
  listQuery.pageSize = val;
  userQuery();
}
const handleCurrentChange = (val) => {
  console.log(`current page: ${val}`)
  listQuery.pageindex = val;
  userQuery();
}
</script>