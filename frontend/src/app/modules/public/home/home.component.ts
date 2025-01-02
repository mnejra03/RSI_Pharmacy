/*import { Component, OnInit } from '@angular/core';
import {ApiService } from '../../../services/api.service';

@Component({
  selector: 'app-home',
  standalone: false,

  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit{

  data: any;
  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.apiService.getData().subscribe(response => {
      this.data = response;
      console.log(this.data);
    });
  }
}*/
/*import {Component, OnInit} from '@angular/core';
import {ApiService } from '../../../services/api.service';
@Component({
  selector: 'app-home',
  standalone:false,
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements  OnInit {
  data: any;

  constructor(private apiService: ApiService) {
  }

  ngOnInit(): void {
    this.apiService.getData().subscribe(response => {
      this.data = response;
      console.log(this.data);
    });
  }
    banners = [
      {image: 'images/avene.jpg', title: 'Baner 1'},
      {image: 'images/oralb.jpg', title: 'Baner 2'},
      {image: 'images/vichy.jpg', title: 'Baner 3'}
    ];

    activeIndex = 0;

    nextSlide()
    {
      this.activeIndex = (this.activeIndex + 1) % this.banners.length;
    }

    prevSlide()
    {
      this.activeIndex = (this.activeIndex - 1 + this.banners.length) % this.banners.length;
    }
}*/
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'; // Import Router
@Component({
  selector: 'app-home',
  standalone:false,
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent{

}

