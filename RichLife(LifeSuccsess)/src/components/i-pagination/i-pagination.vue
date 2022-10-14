<template>
   <div class="i-pagination">
      <ul>
         <li class="nav left disabled"><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-arrow-left"></use></svg></li>
         <li class="active"><span>1</span></li>
         <li><span>2</span></li>
         <li class="ellipsis"><span>...</span></li>
         <li><span>3</span></li>
         <li class="nav right"><svg><use xlink:href="/assets/img/svg-sprite.svg#icon-arrow-right"></use></svg></li>
      </ul>
   </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator"

@Component
export default class IPaginationComponent extends Vue {

   @Prop({ type: Number, default: 0 }) count: number
   @Prop({ type: Number, default: 0 }) size: number

   
   @Watch('count') changeCount() {
      console.log(this.count, 'count');
   }

   @Watch('size') changeSize() {
      console.log(this.size, 'size');
   }

   created() {
      console.log(this.count, 'count');
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

.i-pagination ul li {
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

.i-pagination ul li svg {
   width: 13px;
   height: 16px;
   fill: #121B23;
   transition: all 0.2s ease-out;
}

.i-pagination ul li:not(:last-child) {
   margin-right: 5px;
}



/* active */
.i-pagination ul li.active,
.i-pagination ul li:hover {
   background: #12be83;
   color: #FFE6E6;
}

.i-pagination ul li.active svg,
.i-pagination ul li:hover svg {
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

@media all and (max-width: 320px) {
   .i-pagination ul li { width: 33px; height: 33px; }
}
</style>