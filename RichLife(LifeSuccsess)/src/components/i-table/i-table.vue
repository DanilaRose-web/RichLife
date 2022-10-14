<template>
   <div class="i-table-wrap">
      <div class="i-table">
         <div class="head i-table-row">
            <div class="i-table-col"><span>#</span></div>
            <div class="i-table-col"><span>Полис</span></div>
            <div class="i-table-col"><span>Дата</span></div>
            <div class="i-table-col"><span>ФИО</span></div>
            <div class="i-table-col"><span>Е</span></div>
            <div class="i-table-col"><span>Кешбэк</span></div>
            <div class="i-table-col"><span>К выводу</span></div>
         </div>
   
         <template v-if="data">
            <div class="body-wrap" v-for="item in data" :key="item.Id">
               <div class="body i-table-row" >
                  <div class="i-table-col"><span>{{ item.Id }}</span></div>
                  <div class="i-table-col"><span>{{ item.PolicyNumber }}</span></div>
                  <div class="i-table-col"><span>{{ item.Data }}</span></div>
                  <div class="i-table-col"><span>{{ item.Name }}</span></div>
                  <div class="i-table-col"><span>{{ item.EScores }}</span></div>
                  <div class="i-table-col"><span>{{ item.Cashback }}</span></div>
                  <div class="i-table-col"><span>{{ item.MoneyToPay }}</span></div>
               </div>

               <div class="body-collapse-wrap">
                  <div class="body-collapse">
                     <div class="grid-item">
                        <div class="collapse-info">
                           <div class="info-name">Общая сумма: </div>
                           <span>256 156</span>
                        </div>
                        <div class="collapse-info">
                           <div class="info-name">Дата окончания: </div>
                           <span>12.04.2065</span>
                        </div>
                     </div>

                     <div class="grid-item">
                        <div class="collapse-info">
                           <div class="info-name">Сумма следующего платежа: </div>
                           <span>226 265</span>
                        </div>
                        <div class="collapse-info">
                           <div class="info-name">Дата следующего платежа: </div>
                           <span>12.04.2022</span>
                        </div>
                     </div>

                     <div class="grid-item">
                        <div class="collapse-info">
                           <div class="info-name">Выплачено всего: </div>
                           <span>126 597</span>
                        </div>
                        <div class="collapse-info">
                           <div class="info-name">Сумма накоплений: </div>
                           <span>999 999 999</span>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </template>

         
      </div>
   </div>
</template>

<script lang="ts">

import Vue from "vue";
import { Component, Prop } from "vue-property-decorator"
import ITableData from "./models/ITableData";

@Component
export default class ITableComponent extends Vue {
   @Prop({ type: Array, default: () => [] as ITableData[] }) data: ITableData[]


   created() {
      // console.log(this.data);
   }

   mounted() {
      this.initjQueryAccordion()
   }

   initjQueryAccordion() {
      $('.body-collapse-wrap').hide()

      $('.body-wrap').on('click', function () {
         $('.body-wrap').not($(this)).removeClass('active')
         $('.body-collapse-wrap').not($(this).children('.body-collapse-wrap')).slideUp()
         $(this).toggleClass('active').children('.body-collapse-wrap').slideToggle();
      })
   }

}
</script>

<style scoped>

.i-table-wrap {
   margin: 0 7.5px;
   overflow-x: auto;
}

.i-table {
   padding: 15px 7.5px;
   display: table;
   overflow-x: auto;
   width: 100%;
}

.i-table .i-table-row {
   display: grid;
   grid-template-columns: 75px minmax(114px, 1fr) minmax(114px, 1fr) minmax(226px, 2fr) minmax(114px, 1fr) minmax(114px, 1fr) minmax(114px, 1fr);
   grid-template-rows: 1fr;
   gap: 2px;
}

.i-table .i-table-row.head {
   margin-bottom: 20px;
   border-bottom: 1px solid #12be83;
}

.i-table .body-wrap {
   box-shadow: 0 0 16px 0 rgba(190, 190, 204, 0.4);
   border-radius: 28px;
   transition: all 0.3s ease-out;
}

.i-table .i-table-row.body:hover,
.body-wrap.active .i-table-row.body {
   background: #12be83;
}

.i-table .i-table-row.body {
   border-radius: 28px;
   background: #fff;
   cursor: pointer;
   transition: all 0.2s ease-out;
}

.i-table .i-table-row.body:hover .i-table-col,
.body-wrap.active .i-table-col {
   color: #fff;
}

.i-table .body-wrap:not(:last-child) {
   margin-bottom: 15px;
}

.i-table .i-table-col {
   padding: 5px 5px 5px 15px;
   display: flex;
   align-items: center;
   font-size: 18px;
   font-weight: 600;
   color: #121B23;
   min-height: 52px;
   overflow: hidden;
}

.i-table-row.body .i-table-col {
   font-size: 16px;
   font-weight: 500;
}

.i-table .i-table-col span {
   display: -webkit-box;
   -webkit-line-clamp: 2;
   -webkit-box-orient: vertical;
   overflow: hidden;
   line-height: 120%;
}




/* scroll-content */
.i-table .scroll-content {
   max-height: 900px;
   height: 100%;
   overflow: auto;
}


/* body-collapse */
.body-collapse {
   padding: 30px 15px;
   /* box-shadow: 0 0 16px 0 rgba(190, 190, 204, 0.4); */
   border-bottom-left-radius: 28px;
   border-bottom-right-radius: 28px;
   display: flex;
   justify-content: space-between;
}

.grid-item {
   display: flex;
   flex-direction: column;
   align-items: flex-start;
}

.collapse-info {
   display: flex;
   align-items: center;
}

.collapse-info:not(:last-child) {
   margin-bottom: 15px;
}

.info-name {
   margin-right: 10px;
   font-size: 14px;
   font-weight: 500;
   line-height: 120%;
   color: #121B23;
}

.info-name + span {
   font-size: 15px;
   font-weight: 500;
   color: #12be83;
   text-shadow: 0 0 5px #ffffff, 0 0 1px #ffffff, 0 0 1px #ffffff, 0 0 1px #00ff00, 0 0 1px #00ff00, 0 0 1px #00ff00, 0 0 1px #00ff00, 0 0 1px #00ff00;
}
</style>