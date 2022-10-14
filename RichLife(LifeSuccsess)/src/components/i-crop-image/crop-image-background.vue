<template>
	<div>
		<div class="image-m" :style="[background]"></div>
		<div class="cr-faded"></div>
	</div>
	
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator"

@Component
export default class CropImageBackgroundComponent extends Vue {
		//#region props
		@Prop() imageSrc: string;
		@Prop() maxHeight: number;
		@Prop() maxWidth: number;
		@Prop() width: number;
		@Prop() height: number;
		@Prop() frameHeight:number;
		@Prop() frameWidth: number;
		@Prop({default: 0}) frameTop: number;
		@Prop({default: 0}) frameLeft: number;
		//#endregion
    //#region data
		image = new Image();
		imageHeight = 0;
		imageWidth = 0;
		zoom = 1;
		innerHeight = this.height;
		innerWidth = this.width;
		//#endregion
		//#region lifecycles
    created() {
			this.image.src = this.imageSrc;     
			this.image.onload = e => {
			this.imageHeight = this.image.height; 
			this.imageWidth = this.image.width;        	

			this.computeParams();
			
			this.$emit('loaded', { 
				height: this.height ? this.height : this.innerHeight, 
				width: this.width ? this.width : this.innerWidth,
				zoom: this.zoom,
			})   
		}
    }
    mounted() {
    	this.$nextTick(() => { // goose
    		// this.imageHeight = this.image.height; 
      //   	this.imageWidth = this.image.width;        	

      //   	this.computeParams();
        	
    		// this.$emit('loaded', { 
    		// 	height: this.height ? this.height : this.innerHeight, 
    		// 	width: this.width ? this.width : this.innerWidth,
    		// 	zoom: this.zoom,
    		// })    		
    	});    	
		}
		//#endregion
		//#region computed
		get background() {
			
			return {
				width: this.converToPixel(this.innerWidth),
				height: this.converToPixel(this.innerHeight),
				backgroundImage: `url('${this.imageSrc}')`,
				backgroundSize: `auto ${this.imageHeight / this.zoom}px`,
				backgroundPosition: `${this.converToPixel(-this.frameLeft / this.zoom)} ${ this.converToPixel(-this.frameTop / this.zoom)}`,
			}
		}
		
		//#endregion
		//#region methods
		computeParams(){
			if(this.width != undefined && this.height != undefined){
				this.zoom = (this.frameHeight / (this.height || this.innerHeight)) || 1;	
				return;
			}
			
			let aspectHeight = this.imageHeight / this.maxHeight;
			let aspectWidth = this.imageWidth / this.maxWidth;
			let maxAspect = Math.max(aspectWidth, aspectHeight);
			this.innerWidth = this.imageWidth / maxAspect;
			this.innerHeight = this.imageHeight / maxAspect;  
			this.zoom = this.imageHeight / this.innerHeight;
		}
		converToPixel(val: string | number){
			return val == "auto" ? "auto" : val + "px";
		}
		//#endregion

		imageSizeOnMobile() {
			let windowWidth = window.innerWidth
			if (windowWidth <= 540) {
				
			}
		}
}
</script>

<style lang="less" scoped>
.image-m {
	width: 450px;
	height: 150px;
	position: relative;
	overflow: hidden;
	.cr-background {
		z-index: 1;
		-webkit-user-select: none;
		-moz-user-select: none;
	}
}
.cr-faded {
	//cursor: crosshair;
	left: 0px;
	top: 0px;
	width: 100%;
	height: 100%;
	z-index: 1030;
	display: block;
	border-radius: 2px;
	position: absolute;
	background-color: rgba(0, 0, 0, 0.6);
}
</style>