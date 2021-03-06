import {Component, Input, OnInit} from '@angular/core';
import {ImageService} from "../image.service";

@Component({
  selector: 'app-image',
  templateUrl: './image.component.html',
  styleUrls: ['./image.component.scss']
})
export class ImageComponent implements OnInit {
  @Input()
  storeId?: string;
  imageSource: string | ArrayBuffer | null = "https://i.ytimg.com/vi/iD0wFUlZGv0/maxresdefault.jpg";

  constructor(private _fileService: ImageService) {
  }

  ngOnInit(): void {
    if (this.storeId)
      this._fileService.getImageByStoreId(this.storeId).subscribe(data => {
        this.createImageFromBlob(data)
      })
  }

  private createImageFromBlob(image: Blob) {
    let reader = new FileReader();
    reader.addEventListener("load", () => {
      this.imageSource = reader.result;
    }, false);

    if (image) {
      reader.readAsDataURL(image);
    }
  }
}
