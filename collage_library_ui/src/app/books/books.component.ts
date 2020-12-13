import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent implements OnInit {

  bookData:Partial<IBookInfo[]> = [];
  userName:string;
  host: string;
  user: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('CurrentUser'));
    this.userName = this.user.name;
    this.getBooks();
  }

  getBooks() {
    this.http.get<any>("./assets/config.json").subscribe(x=>{
      this.host = x.BooksHost;
      var url = x.BooksHost + "books";
    if(this.user.role == "Student"){
      url = x.BooksHost + "books/allbooks/"+this.user.userId;
    }
      this.http.get<Partial<IBookInfo[]>>(url).subscribe(data=>{
        this.bookData = data;
      });
    }) 
  }

  buyNow(bookId: string){
    var url = this.host + "books/allocate";
    const data = {userId: this.user.userId, bookId, method:"add"}
    this.http.post<any>(url,
      data,{
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }).subscribe(x=>{
      this.getBooks();
    })
  }

}

export interface IBookInfo{
  id:string;
  name:string;
  author:string;
  description:string;
  available:boolean
}
