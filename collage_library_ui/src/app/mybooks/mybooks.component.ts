import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IBookInfo } from '../books/books.component';

@Component({
  selector: 'app-mybooks',
  templateUrl: './mybooks.component.html',
  styleUrls: ['./mybooks.component.scss']
})
export class MybooksComponent implements OnInit {

  bookData:Partial<IBookInfo[]> = [];
  userName:string;
  host: string;
  user: any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.user = JSON.parse(localStorage.getItem('CurrentUser'));
    this.userName = this.user.name;
    this.getBooks(this.user.userId);
  }

  getBooks(userId: string) {
    this.http.get<any>("./assets/config.json").subscribe(x=>{
      this.host = x.BooksHost;
      var url = x.BooksHost + "books/mybooks/"+userId;
      this.http.get<Partial<IBookInfo[]>>(url).subscribe(data=>{
        this.bookData = data;
      });
    }) 
  }

  returnBook(bookId: string){
    var url = this.host + "books/allocate";
    const data = {userId: this.user.userId, bookId, method:"remove"}
    this.http.post<any>(url,
      data,{
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }).subscribe(x=>{
      this.getBooks(this.user.userId);
    })
  }

}
