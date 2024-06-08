import { Component, OnInit } from '@angular/core';
import { CommonModule, NgFor } from '@angular/common';
import { BlankComponent } from 'src/app/common/components/blank/blank.component';
import { SectionComponent } from 'src/app/common/components/blank/section/section.component';
import { NavModel } from 'src/app/common/components/blank/models/nav.model';
import { UcafService } from './services/ucaf.service';
import { UcafModel } from './models/ucaf.model';
import { UcafPipe } from './pipes/ucaf.pipe';
import { FormsModule, NgForm } from '@angular/forms';
import { ValidInputDirective } from 'src/app/common/directives/valid-input.directive';
import { LoadingButtonComponent } from 'src/app/common/components/loading-button/loading-button.component';
import { ToastrService, ToastrType } from 'src/app/common/services/toastr.service';
import { RemoveByIdUcafModel } from './models/remove-by-id-ucaf.model';

@Component({
  selector: 'app-ucafs',
  standalone: true,
  imports: [CommonModule,
    BlankComponent,
    SectionComponent,
    UcafPipe,
    FormsModule,
    ValidInputDirective,
    FormsModule,
    LoadingButtonComponent
  ],
  templateUrl: './ucafs.component.html',
  styleUrls: ['./ucafs.component.css']
})
export class UcafsComponent implements OnInit {
  navs: NavModel[] = [
    {
      routerLink: "/",
      class: "",
      name: "Ana Sayfa"
    },
    {
      routerLink: "/ucafs",
      class: "active",
      name: "Hesap Planı"
    },


  ]
  ucafs: UcafModel[] = [];
  filterText: string = "";
  isAddForm: boolean = false;
  ucafType: string = "M";
  isLoading: boolean = false;

  constructor(
    private _ucaf: UcafService,
    private _toastr: ToastrService
  ) { }
  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this._ucaf.getAll(res => this.ucafs = res.data);
  }

  showAddForm() {
    this.isAddForm = true;
  }

  add(form: NgForm) {
    if (form.valid) {
      this.isLoading = true;
      let model = new UcafModel();
      model.code = form.controls["code"].value;
      model.type = form.controls["type"].value;
      model.name = form.controls["name"].value;

      this._ucaf.add(model, (res) => {
        form.controls["code"].setValue("");
        form.controls["name"].setValue("");
        this.ucafType = 'M';

        this.getAll();
        this.isLoading = false;
        this._toastr.toast(ToastrType.Success, res.message, "Başarılı!")
      });
    }

  }

  cancel() {
    this.isAddForm = false;
  }

  removeById(id: string) {
    var result = confirm("Silme işlemi yapmak istiyor musunuz?");
    if (result) {
      let model = new RemoveByIdUcafModel();
      model.id = id;

      this._ucaf.removeById(model, res => {
        this.getAll();
        this._toastr.toast(ToastrType.Info, res.message, "Silme Başarılı!");
      });
    }

  }

  setTrClass(type: string) {
    if (type == "A")
      return "text-danger"
    else if (type == "G")
      return "text-primary";
    else
      return "";
  }
}