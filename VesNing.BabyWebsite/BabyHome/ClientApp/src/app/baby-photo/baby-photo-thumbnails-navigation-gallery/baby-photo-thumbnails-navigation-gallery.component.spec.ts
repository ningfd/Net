import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BabyPhotoThumbnailsNavigationGalleryComponent } from './baby-photo-thumbnails-navigation-gallery.component';

describe('BabyPhotoThumbnailsNavigationGalleryComponent', () => {
  let component: BabyPhotoThumbnailsNavigationGalleryComponent;
  let fixture: ComponentFixture<BabyPhotoThumbnailsNavigationGalleryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BabyPhotoThumbnailsNavigationGalleryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BabyPhotoThumbnailsNavigationGalleryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
