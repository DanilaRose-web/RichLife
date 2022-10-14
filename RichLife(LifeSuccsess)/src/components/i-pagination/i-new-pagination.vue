<template>
   <div class="i-pagination-wrap">
      <template v-if="entriesOnThePage">
         <select class="ppage" v-model="selectedCountOnPage" @change="changePage(currentPage)">
         <option v-for="n in rowCountsSelect" :key="n" v-bind:value="n">{{ n }}</option>
         <!-- <option v-if="showAllSelect" value="">Max</option> -->
         </select>
      </template>

      <div class="i-pagination">
         <a v-bind:class="{ disabled: currentPage === 1 }" @click="changePage(currentPage - 1)" class="prev">
            <svg><use :xlink:href="prev"></use></svg>
         </a>
         
         <ul>
            <template v-for="n in pages">
               <li
                  :key="n"
                  v-bind:class="[{ current: currentPage === n, default: currentPage != n }]"
                  @click="changePage(n)"
                  v-if="n === 1 || n === countPages() || (currentPage - 2 < n && n < currentPage + 2)">
                  <span >{{ n }}</span>
               </li>
               <li v-else-if="(n === 2 && n <= countPages() - 1) || (n === countPages() - 1 && n < countPages() + 2)" :key="n" class="disabled">
                  <span >...</span> 
               </li>
            </template>
         </ul>

         <!-- Страница {{currentPage}} -->
         <a v-bind:class="{ disabled: currentPage == countPages() }" @click="changePage(currentPage + 1)" class="next">
            <svg><use :xlink:href="next"></use></svg>
         </a>
      </div>
   </div>
</template>

<script lang="ts">
import { Component, Vue, Prop, Watch } from 'vue-property-decorator';

@Component
export default class INewPaginationComponent extends Vue {
  @Prop({ default: 1 }) current: number;
  @Prop({ default: 10 }) size: number;
  @Prop({ default: "/assets/img/svg-sprite.svg#icon-arrow-left" }) prev: string;
  @Prop({ default: "/assets/img/svg-sprite.svg#icon-arrow-right" }) next: string;
  @Prop({
    default: function () {
      return [10, 25, 50, 100];
    },
  })
  rowCountsArray: Array<number>;
  @Prop({ default: true }) showAllSelect: Boolean;
  @Prop({ default: 'default', type: String }) theme: string;
  @Prop({ type: Number }) count: number;
  @Prop({ default: true }) showtext: Boolean;
  @Prop({ default: false }) entriesOnThePage: Boolean;
  //#21324f

  currentPage: number = this.current;
  page = 1;
  pages = [1];
  selectedCountOnPage: number = this.size || this.rowCountsArray[0] || 10;

  rowCountsSelect = this.rowCountsArray;

  // @Watch("startPage")
  // onChangeStartPage(){
  //   this.currentPage=this.startPage
  // }
  @Watch('countOnPage')
  countPages(): number {
    if (!this.selectedCountOnPage) return 1;
    return Math.ceil(this.count / this.selectedCountOnPage);
  }
  @Watch('count')
  onChangeCount() {
    this.onUpdateData(this.count);
    //  this.count = this.counts;
  }
 @Watch('size')
  onChangeSize() {
 this.selectedCountOnPage = this.size || this.rowCountsArray[0] || 10;
  }
  created() {
    this.onUpdateData(this.count);
  }
  mounted() {
    this.currentPage = this.current;
  }
  beforeDestroy() {}

  onUpdateData(data: number) {
    // console.log("пагинация onUpdateData", data)
    this.page = data;

    if (this.currentPage > this.countPages()) this.currentPage = this.countPages();
    if (this.currentPage == 0 && this.countPages() > 0) this.currentPage = 1;
    var p = [];
    for (var i = 1; i <= this.countPages(); i++) p.push(i);
    this.pages = p;
    console.log(this.pages, 'pages');
    
  }

  changePage(page: any) {
    if (this.selectedCountOnPage != this.size) {
      this.$emit('onChange', this.getRequest());
    }
    if (this.currentPage === page) return;
    if (!this.selectedCountOnPage) this.currentPage = 1;
    if (page < 1 || (page - 1) * this.selectedCountOnPage >= this.count) return;
    this.currentPage = page;

    this.$emit('onChange', this.getRequest());
  }
  resetCount() {
    this.currentPage = 1;
    this.$emit('onChange', this.getRequest());
  }

  getRequest() {
    if (!this.selectedCountOnPage) return {};
    // console.log({ Page: this.currentPage, CountOnPage: this.selectedCountOnPage })
    return { Page: this.currentPage, CountOnPage: this.selectedCountOnPage };
  }
}
</script>

<style scoped>

.i-pagination {
   display: flex;
   align-items: center;
   justify-content: flex-end;
}

.i-pagination ul {
   display: flex;
   align-items: center;
}

.i-pagination ul li,
.i-pagination a {
   width: 40px;
   height: 40px;
   border-radius: 5px;
   background: #fff;
   font-size: 17px;
   font-weight: 600;
   line-height: 109%;
   color: #121B23;
   cursor: pointer;
   display: flex;
   align-items: center;
   justify-content: center;
   box-shadow: 0 0 16px 0 rgba(190, 190, 204, 0.4);
   transition: all 0.2s ease-out;
}

.i-pagination a.prev {
   margin-right: 5px;
}

.i-pagination a.next {
   margin-left: 5px;
}

.i-pagination ul li svg,
.i-pagination a svg {
   width: 13px;
   height: 16px;
   fill: #121B23;
   transition: all 0.2s ease-out;
}

.i-pagination ul li:not(:last-child) {
   margin-right: 5px;
}



/* active */
.i-pagination ul li.current,
.i-pagination ul li:hover,
.i-pagination a:hover,
.i-pagination a:active {
   background: #12be83;
   color: #FFE6E6;
}

.i-pagination ul li.current svg,
.i-pagination ul li:hover svg,
.i-pagination a:hover svg,
.i-pagination a.current svg {
   fill: #FFE6E6;
}



/* disabled */
.i-pagination ul li.disabled {
   color: rgba(18, 27, 35, 0.3);
   cursor: auto;
}

.i-pagination ul li.disabled svg {
   fill: rgba(18, 27, 35, 0.3);
}

.i-pagination ul li.disabled:hover {
   color: rgba(18, 27, 35, 0.3);
   background: #fff;
}

.i-pagination ul li.disabled:hover {
   fill: rgba(18, 27, 35, 0.3);
}



/* ellipsis */
.i-pagination ul li.ellipsis {
   background: transparent;
   box-shadow: none;
   width: 30px;
   cursor: auto;
}

.i-pagination ul li.ellipsis:hover {
   color: #121B23;
}

@media all and (max-width: 430px) {
   .i-pagination a.prev { margin-bottom: 5px; margin-right: 0; }
   .i-pagination a.next { margin-top: 5px; margin-left: 0; }
   .i-pagination { flex-direction: column; align-items: flex-start; }
}

@media all and (max-width: 330px) {
   .i-pagination ul li, .i-pagination a { width: 33px; height: 33px; }
}
</style>
