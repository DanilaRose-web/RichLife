<template>
	<div class="cr-frame" v-if="isShow"
		ref="frame"           
		:style="[frame, {cursor: cursorIn}]">
		<div class="path-left path"></div>
		<div class="path-right path"></div>
		<div class="path-top path"></div>
		<div class="path-bottom path"></div>

		<div class="cr-frame-inner"
			ref="frame-inner"
			:class="[type]"
			:style="[background]"
			@mousedown.left="(e) => frameMouseDown(e)">
		</div>

		<div class="cr-anchor cr-an-1" ref="an-1" @mousedown.left="(e) => cornerMouseDown(e, false, false, true, true)"></div>
		<div class="cr-anchor cr-an-2" ref="an-2" @mousedown.left="(e) => cornerMouseDown(e, true, false, false, true)"></div>
		<div class="cr-anchor cr-an-3" ref="an-3" @mousedown.left="(e) => cornerMouseDown(e, false, true, true, false)"></div>
		<div class="cr-anchor cr-an-4" ref="an-4" @mousedown.left="(e) => cornerMouseDown(e, true, true, false, false)"></div>
		
	</div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator"
@Component({
    name: 'crop-image-frame'
})
export default class CropImageFrameComponent extends Vue{	
	//#region props
	@Prop() type: string;
	@Prop() imageSrc: string;
	@Prop() aspectRatio: number;
	@Prop({default: false}) isLiveUpdate: boolean;
	@Prop({default: 0.8}) defaultSize: number;
	@Prop({default: 175}) minWidth: number;
	@Prop({default: 50}) minHeight: number;

	// смещение с предыдущего кропа
	@Prop({default: 0}) frameHeight: number;
	@Prop({default: 0}) frameWidth: number;
	@Prop({default: 0}) frameTop: number;
	@Prop({default: 0}) frameLeft: number;
	//#endregion
	//#region data	
	isShow = false;
	left: number | string = 10;
	top: number | string = 10;
	right: number | string = 'auto';
	bottom: number | string = 'auto';
	maxHeight = 80;
	maxWidth = 321;
	zoom = 1;
	currentHeight = 0;
	currentWidth = 0;

	startPoint = { // goose - type
		x: 0,
		y: 0,
		left: 0,
		top: 0,
		right: 0,
		bottom: 0,
		beginHeight: 0,
		beginWidth: 0,
	}
	
	isCornerTouch = false;
	isMove = false;
	cursorIn = "move";
	cursorOut = "crosshair";

	image = new Image();
	imageHeight = 0;
	imageWidth = 0;

	shiftTop = 0;
	shiftLeft = 0;
	update = false;	
	//#endregion
	//#region lifecycle
	created(){
		this.image.src = this.imageSrc; 
	}
	//#endregion
	
	//#region computed		
	//выделенная часть картинки
	get background(): Object {			
		return {
			backgroundImage: `url('${this.imageSrc}')`,	
			backgroundPosition: `${this.invertValue(this.getLeft)} ${this.invertValue(this.getTop)}`,
			backgroundSize: `auto ${this.converToPixel(this.imageHeight / this.zoom)}`
		}
	}
	//положение выделения на фоне
	get frame(): Object {
		return {		
			left: this.converToPixel(this.left),
			top: this.converToPixel(this.top),		
			right: this.converToPixel(this.right),
			bottom: this.converToPixel(this.bottom),
			height: this.converToPixel(this.currentHeight),
			width: this.converToPixel(this.currentWidth),
		};
	}
	get getLeft(): number {
		return (this.left == "auto" ? 
			this.maxWidth - Number(this.right) - this.currentWidth :
			Number(this.left)) + this.shiftLeft;
	}
	get getTop(): number {
		return (this.top == "auto" ? 
			this.maxHeight - Number(this.bottom) - this.currentHeight :
			Number(this.top)) + this.shiftTop;
	}
	//#endregion	
	show(data: any){
		this.maxHeight = data.height;
		this.maxWidth = data.width;
		this.zoom = data.zoom;
		this.isShow = true;
		this.$nextTick(function(){
			this.init();
			//нажатия телефона
			this.listenTouchToMove();
			this.listenTouchToResize();
		});
		document.ondragstart = function() { return false; };
		document.documentElement.addEventListener("mouseup", this.mouseUp, false);
	}
	//слушать нажатия тача телефона
	listenTouchToMove() {
		(this.$refs['frame-inner'] as any).addEventListener('touchstart', (e: MouseEvent) => {
			this.frameMouseDown(e);
		});	
		(this.$refs['frame-inner'] as any).addEventListener('touchmove', (e: MouseEvent) => {
			e.preventDefault();
			e.stopPropagation();
			this.frameMouseMove(e);
		});		
		(this.$refs['frame-inner'] as any).addEventListener('touchend', (e: MouseEvent) => {
			this.isMove = false;
		});
	}
	//нажатия тача телеофна на якоря ресайза
	listenTouchToResize(){			
		let anchors = [this.$refs['an-1'], this.$refs['an-2'], this.$refs['an-3'], this.$refs['an-4']];

		(this.$refs['an-1'] as any).addEventListener('touchstart', (e: MouseEvent) => {
			this.cornerMouseDown(e, false, false, true, true)
		});		
		(this.$refs['an-2'] as any).addEventListener('touchstart', (e: MouseEvent) => {
			this.cornerMouseDown(e, true, false, false, true)
		});	
		(this.$refs['an-3'] as any).addEventListener('touchstart', (e: MouseEvent) => {
			this.cornerMouseDown(e, false, true, true, false)
		});	
		(this.$refs['an-4'] as any).addEventListener('touchstart', (e: MouseEvent) => {
			this.cornerMouseDown(e, true, true, false, false)
		});	

		anchors.forEach(item => {
			(item as any).addEventListener('touchmove', (e: MouseEvent) => { 
				e.preventDefault();
				e.stopPropagation();
				this.cornerMouseMove(e); 
			});
		})		
		anchors.forEach(item => {
			(item as any).addEventListener('touchend', (e: MouseEvent) => { this.mouseUp(e); });
		})		
	}
	init(){
		this.imageHeight = this.image.height; 
		this.imageWidth = this.image.width;

		this.defaultFramePosition();
		this.computeParams();
		this.emitParams();
	}
	defaultFramePosition(){
		let height = this.maxHeight * this.defaultSize;
		let width = height * Number(this.aspectRatio);
		if(width > this.maxWidth){ 
			width = this.maxWidth * this.defaultSize;
			height = width / Number(this.aspectRatio);
		}
		this.currentWidth = width;
		this.currentHeight = height;
		this.left = (this.maxWidth - this.currentWidth) / 2;
		this.top = (this.maxHeight - this.currentHeight) / 2;
	}
	computeParams(){
		this.shiftLeft = this.frameLeft / this.zoom;
			this.shiftTop = this.frameTop / this.zoom;
	}
	converToPixel(val: string | number){
		return val == "auto" ? "auto" : val + "px";
	}
	invertValue(val: string | number){
		return val == "auto" ? "auto" : -val + "px";
	}
	getPosition(e: any){
		return e.changedTouches ? e.changedTouches[0] : e;
	}

	// передвижение фоейма
	frameMouseDown(e: MouseEvent) {
		this.isMove = true;
		document.documentElement.addEventListener("mousemove", this.frameMouseMove, false);
		document.documentElement.onselectstart = function() { return false; };
		this.isCornerTouch = false;
		let shift = this.getPosition(e);
		this.startPoint.x = shift.pageX;
		this.startPoint.y = shift.pageY;
		
		this.startPoint.left = (this.$refs.frame as any).offsetLeft; 
		this.startPoint.top = (this.$refs.frame as any).offsetTop; 
		this.left = (this.$refs.frame as any).offsetLeft;
		this.top = (this.$refs.frame as any).offsetTop;
		this.right = "auto";
		this.bottom = "auto";
	}
	frameMouseMove(e: MouseEvent){
		let shift = this.getPosition(e);
		if(!this.isMove && !this.isCornerTouch) return;
		let dx = shift.pageX - this.startPoint.x;
		let dy = shift.pageY - this.startPoint.y;
		this.validateBorderOutMove(dx, dy);	

		this.emitParams();
	}

	// перетягивание за углы
	cornerMouseDown(e: MouseEvent, left: boolean, top: boolean, right: boolean, bottom: boolean) {
		this.isMove = true;
		document.documentElement.addEventListener("mousemove", this.cornerMouseMove, false);
		document.documentElement.onselectstart = function() { return false; };
		this.isCornerTouch = true;

		let shift = this.getPosition(e);
		this.startPoint.x = shift.pageX;
		this.startPoint.y = shift.pageY;
		this.startPoint.beginHeight = this.currentHeight;
		this.startPoint.beginWidth = this.currentWidth;
		
		this.left = left ? (this.$refs.frame as any).offsetLeft : 'auto'; 
		this.top = top ? (this.$refs.frame as any).offsetTop : 'auto'; 
		this.right = right ? 
			(this.maxWidth - (this.$refs.frame as any).offsetLeft - this.currentWidth) :
				'auto'; 
		this.bottom = bottom ? 
			(this.maxHeight - (this.$refs.frame as any).offsetTop - this.currentHeight) : 
			'auto'; 
	}
	cornerMouseMove(e: MouseEvent){
		let shift = this.getPosition(e);
		if(!this.isMove && this.isCornerTouch) return;
		let dx = shift.pageX - this.startPoint.x;
		let dy = shift.pageY - this.startPoint.y;
		let res = this.saveAspectRatio(dx, dy);
		this.validateBorderOutSize(res.dx, res.dy);	
		this.validatorMaxSize();
		this.validateAspectRatio();	

		this.emitParams()
	}
	setPrev() {
		if(this.startPoint.x < 0) this.startPoint.x = 0;
		if(this.startPoint.x > this.maxWidth) this.startPoint.x = this.maxWidth;

		if(this.startPoint.y < 0) this.startPoint.y = 0;
		if(this.startPoint.y > this.maxHeight) this.startPoint.y = this.maxHeight;
	}
	// отпускаем мышку
	mouseUp(e: MouseEvent) {
		this.isMove = false;
		document.documentElement.removeEventListener("mousemove", this.cornerMouseMove, false);
		document.documentElement.removeEventListener("mousemove", this.frameMouseMove, false);
		document.documentElement.onselectstart = function() { return true; };
	}

	// выход за границы пр иперетаскивание и ресайзе
	validateBorderOutMove(dx: number, dy: number) {
		let left = this.startPoint.left + dx;
		let top = this.startPoint.top + dy;
		if(left < 0) this.left = 0;
		else if(left + this.currentWidth > this.maxWidth) this.left = this.maxWidth - this.currentWidth;
		else this.left = left;
		if(top < 0) this.top = 0;
		else if(top + this.currentHeight > this.maxHeight) this.top = this.maxHeight - this.currentHeight;
		else this.top = top;
	}
	validateBorderOutSize(dx: number, dy: number){
		let paddingHeight = Number(this.top == "auto" ? this.bottom : this.top);
		let paddingWidth = Number(this.left == "auto" ? this.right : this.left);

		let currentWidth = Number(this.startPoint.beginWidth + dx * (this.right == "auto" ? 1 : -1));
		let currentHeight = Number(this.startPoint.beginHeight + dy * (this.bottom == "auto" ? 1 : -1));
		
		if(currentWidth + paddingWidth > this.maxWidth) 
			this.currentWidth = this.maxWidth - paddingWidth;		
		else this.currentWidth = currentWidth;

		if(currentHeight + paddingHeight > this.maxHeight) 
			this.currentHeight = this.maxHeight - paddingHeight;
		else this.currentHeight = currentHeight;
	}
	validateAspectRatio(){
		let paddingHeight = Number(this.top == "auto" ? this.bottom : this.top);
		let paddingWidth = Number(this.left == "auto" ? this.right : this.left);

		if(this.currentHeight * Number(this.aspectRatio) + paddingWidth < this.maxWidth) {
			this.currentWidth = this.currentHeight * Number(this.aspectRatio);
		}
		if(this.currentWidth / Number(this.aspectRatio) + paddingHeight < this.maxHeight) {
			this.currentHeight = this.currentWidth / Number(this.aspectRatio);
		}
	}
	validatorMaxSize(){
		if(this.currentWidth < this.minWidth) this.currentWidth = this.minWidth;
		if(this.currentHeight < this.minHeight) this.currentHeight = this.minHeight;
	}

	// сохранение соотношения сторон
	saveAspectRatio(dx: number, dy: number){			
		if(!this.aspectRatio) return {dx: dx, dy: dy};
		if( this.aspectRatio < 1) {
			dx = dy * Number(this.aspectRatio);
		} else {
			dy = (this.bottom == "auto" ? 1 : -1) * (this.right == "auto" ? 1 : -1) * dx / Number(this.aspectRatio);
		}
		return {dx: dx, dy: dy};				
	}

	getParams(){
		return {
			width: this.currentWidth * this.zoom,
			height: this.currentHeight * this.zoom,
			left: (this.left == "auto" ? this.maxWidth - Number(this.right) - this.currentWidth : Number(this.left)) * this.zoom + this.frameLeft,
			top: (this.top == "auto" ? this.maxHeight - Number(this.bottom) - this.currentHeight : Number(this.top)) * this.zoom + this.frameTop,
		}
	}
	forceUpdate() {
		this.$emit("update", this.getParams());	
	}
	emitParams(){
		if(this.isLiveUpdate){
			this.update = !this.update;
			this.update && this.$emit("update", this.getParams());					
		}			
	}
}

export interface StartPoint {
	x: number;
	y: number;
	left: number;
	top: number;
	right: number;
	bottom: number;
	beginHeight: number;
	beginWidth: number;
}

</script>

<style lang="less" scoped>
.cr-frame {
	position: absolute;
	cursor: move;
	z-index: 1040;
	display: block;
	.path{
		position: absolute;
		z-index: 1049;
		background-color:  hsla(0, 0%, 100%, 0.3);
	}
	.path-left{
		width: 1px;
		height: 100%;
		top: 0px;
		left: 0px;
	}
	.path-right{
		width: 1px;
		height: 100%;
		right: 0px;
		top: 0px;
	}
	.path-bottom{
		height: 1px;
		width: 100%;
		bottom: 0px;
		left: 0px;
	}
	.path-top{
		height: 1px;
		width: 100%;
		top: 0px;
		left: 0px;
	}
	&:active .path{
		background-color: hsla(0, 0%, 100%, 0.7);
	}
	&:active ~ .cr-anchor {
		background-color: rgba(255, 255, 255, 0.7);
	}
	.cr-frame-inner {
		position: absolute;
		top: 0;
		bottom: 0;
		left: 0;
		right: 0;
		overflow: hidden;
		.cr-v-background {
			position: absolute;
			z-index: 1;
			top: -15px;
			left: -19px;
			-webkit-user-select: none;
			-moz-user-select: none;
		}
	}
}
.cr-anchor {
	z-index: 1050;
	display: block;
	position: absolute;
	background-color: rgba(255, 255, 255, 0.3);
	height: 10px;
	width: 10px;
	border: 1px solid #ccc;
}
.cr-an-1,
.cr-an-4 {
	cursor: nw-resize;
}
.cr-an-2,
.cr-an-3 {
	cursor: ne-resize;
}
.cr-an-5,
.cr-an-8 {
	cursor: e-resize;
}
.cr-an-6,
.cr-an-7 {
	cursor: n-resize;
}
.cr-an-1{
	top: -5px;
	left: -5px;
}
.cr-an-2{
	top: -5px;
	right: -5px;
}
.cr-an-3{
	bottom: -5px;
	left: -5px;
}
.cr-an-4{
	bottom: -5px;
	right: -5px;
}
.cr-an-5{
	top: calc(~"50% - 5px");
	left: -5px;
}
.cr-an-6{
	left: calc(~"50% - 5px");
	top: -5px;
}
.cr-an-7{
	left: calc(~"50% - 5px");
	bottom: -5px;
}
.cr-an-8{
	top: calc(~"50% - 5px");
	right: -5px;
}
.cropAvatar{
	border-radius: 50%;
}
</style>