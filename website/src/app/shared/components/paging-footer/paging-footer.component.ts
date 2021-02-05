import {Component, Input, OnInit, EventEmitter, Output} from '@angular/core';

@Component({
  selector: 'app-paging-footer',
  templateUrl: './paging-footer.component.html',
  styleUrls: ['./paging-footer.component.css']
})
export class PagingFooterComponent implements OnInit {
  @Input() totalCount: number;
  @Input() pageSize: number;
  @Output() pageChanged = new EventEmitter<number>();

  constructor() { }

  ngOnInit(): void {
  }

  onPagingFooterChanged(event: any): void {
  this.pageChanged.emit(event.page);
}

}
