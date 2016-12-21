"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require("@angular/core");
var speed_service_1 = require("./speed.service");
var Hero = (function () {
    function Hero() {
    }
    return Hero;
}());
exports.Hero = Hero;
var AppComponent = (function () {
    function AppComponent(speedService) {
        this.speedService = speedService;
    }
    AppComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.speedService.getSpeeds()
            .subscribe(function (speeds) {
            console.log(speeds);
            _this.speeds = speeds;
            console.log(_this.speeds);
        }, function (error) { return console.log('ERROR: ' + error); });
    };
    return AppComponent;
}());
AppComponent = __decorate([
    core_1.Component({
        selector: 'my-app',
        template: "\n    <h1>DS Speeds</h1>\n    <h2>All Speeds</h2>\n    <div>\n        <speedlist [speeds]=\"speeds\"></speedlist>\n    </div>\n    "
    }),
    core_1.Injectable(),
    __metadata("design:paramtypes", [speed_service_1.SpeedService])
], AppComponent);
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map