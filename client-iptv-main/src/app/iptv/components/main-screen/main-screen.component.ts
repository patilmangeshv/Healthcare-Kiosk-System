import { Component, OnInit, ElementRef, ViewChild, AfterViewInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { saveAs } from 'file-saver';

import { AuthService } from '../../../core/services/auth.service';
import { BoxServiceIPTV } from '../../../iptv/models/box-service-iptv';
import { BoxServiceService } from '../../../iptv/services/box-service.service';
import { Subscription } from 'rxjs';
import { User } from 'src/app/core/models/user';
import { take } from 'rxjs/operators';

interface IVideoFile {
  fileName: string,
  fileType: string,
}

const VideoSrcPath = "assets/videos/source.json";

@Component({
  selector: 'app-main-screen',
  templateUrl: './main-screen.component.html',
  styleUrls: ['./main-screen.component.css']
})
export class MainScreenComponent implements OnInit {
  public _boxes: BoxServiceIPTV[] | undefined;

  serviceNameDetails: Array<string> = [];

  public deskCode = "";
  public adminMessage = 'Dynamic message from admin user...';
  public hospitalNameFR = 'L’Hôpital Central de l’Armée';
  public hospitalNameAR = 'المستشفى  المركزي للجيش';
  public systemDate = new Date();

  public videoFiles: IVideoFile[] = [];

  public videoSrc: string[] = [];

  @ViewChild('video0', { static: true }) private vidElement0?: ElementRef;
  @ViewChild('video1', { static: true }) private vidElement1?: ElementRef;
  @ViewChild('video2', { static: true }) private vidElement2?: ElementRef;
  @ViewChild('video3', { static: true }) private vidElement3?: ElementRef;

  @ViewChild('fileElement', { static: true }) private fileElement?: ElementRef;
  @ViewChild('fileSelect', { static: true }) private fileSelect?: ElementRef;

  public user?: User;

  constructor(private _http: HttpClient
    , private _authService: AuthService
    , private _boxServiceService: BoxServiceService
  ) { }

  async getVideoSrc() {
    this._http.get(VideoSrcPath).subscribe((data: any) => {
      if (data) {
        this.videoSrc = data;
      } else {
        // add blank path
        this.videoSrc.push("");
        this.videoSrc.push("");
        this.videoSrc.push("");
        this.videoSrc.push("");
      }
    }, error => {
      console.log("Error 4: " + error);
    });
  }

  async saveVideoSrc() {
    const blob = new Blob([JSON.stringify(this.videoSrc)], { type: 'application/json' });
    saveAs(blob, "source.json");
  }

  async ngOnInit() {
    // refresh call every 10 seconds to display current date and time
    setInterval(() => {
      this.systemDate = new Date();
    }, 10000);

    // 2. Method for immediate subscribing and getting value and immediate unsubscribing the subscription
    this._authService.user.pipe(take(1)).subscribe(newUser => {
      if (newUser) {
        this.user = newUser;
        this.deskCode = this.user.deskCode;
      }
    });

    // read from asset local file
    await this.getVideoSrc();

    // 1. Bind file select button click with File click event
    this.fileSelect?.nativeElement.addEventListener("click", (ev: Event) => {
      if (this.fileElement) {
        this.fileElement.nativeElement.click();
      }
    });
    // refresh call every 5 seconds to display current and total counts
    setInterval(async () => {
      if (this.user) {
        this._boxes = await this._boxServiceService.getBoxServicesIPTV(this.user.deskId);
      }
    }, 5000);


    if (this.user) {
      this._boxes = await this._boxServiceService.getBoxServicesIPTV(this.user.deskId);

      this.serviceNameDetails = [];
      if (this._boxes) {
        this._boxes.forEach((element: any) => {
          this.serviceNameDetails.push(element.serviceName);
        });
        this.serviceNameDetails = [...new Set(this.serviceNameDetails)];
      }
    }

    // 1. Play first video directly
    this.vidElement0!.nativeElement.style.display = "block";
    this.vidElement0?.nativeElement.addEventListener('loadeddata', async (ev: Event) => {
      if (this.vidElement0?.nativeElement.readyState >= 3) {
        this.vidElement0!.nativeElement.muted = false;  //to avoid error Uncaught (in promise) DOMException: play() failed because the user didn't interact with the document first.
        this.vidElement0!.nativeElement.muted = true;
        this.vidElement0!.nativeElement.muted = false;
        this.vidElement0?.nativeElement.play();
      }
    });

    // 2. Pause and hide rest of the videos
    this.vidElement1!.nativeElement.style.display = "none";
    this.vidElement1!.nativeElement.pause();

    this.vidElement2!.nativeElement.style.display = "none";
    this.vidElement2!.nativeElement.pause();

    this.vidElement3!.nativeElement.style.display = "none";
    this.vidElement3!.nativeElement.pause();

    // 3. Add event listener for the video play ended and start playing next video
    this.vidElement0?.nativeElement.addEventListener('ended', async (ev: Event) => {
      this.vidElement0!.nativeElement.style.display = "none";
      this.vidElement1?.nativeElement.play();
      this.vidElement1!.nativeElement.style.display = "block";
    });

    this.vidElement1?.nativeElement.addEventListener('ended', async (ev: Event) => {
      this.vidElement1!.nativeElement.style.display = "none";
      this.vidElement2?.nativeElement.play();
      this.vidElement2!.nativeElement.style.display = "block";
    });

    this.vidElement2?.nativeElement.addEventListener('ended', async (ev: Event) => {
      this.vidElement2!.nativeElement.style.display = "none";
      this.vidElement3?.nativeElement.play();
      this.vidElement3!.nativeElement.style.display = "block";
    });

    this.vidElement3?.nativeElement.addEventListener('ended', async (ev: Event) => {
      this.vidElement3!.nativeElement.style.display = "none";
      this.vidElement0?.nativeElement.play();
      this.vidElement0!.nativeElement.style.display = "block";
    });
  }

  async fileChangeListener(e: any) {
    const input = e.target;
    // this.uploadFileName = input.files[0].name;

    this.videoFiles = new Array<IVideoFile>();
    this.videoSrc = [];

    for (let index = 0; index < input.files.length; index++) {
      const file = input.files[index];

      this.videoSrc[index] = "assets\\videos\\" + file.name;

      // add video file
      const videoFile: IVideoFile = { fileName: "assets\\videos\\" + file.name, fileType: file.type };
      this.videoFiles.push(videoFile);
    }
    // store value in local storage
    // localStorage.setItem("videoSrc", JSON.stringify(this.videoSrc));

    await this.saveVideoSrc();

    this.vidElement0!.nativeElement.style.display = "block";
    this.vidElement0!.nativeElement.play();
    // 2. Pause and hide rest of the videos
    this.vidElement1!.nativeElement.style.display = "none";
    this.vidElement1!.nativeElement.pause();

    this.vidElement2!.nativeElement.style.display = "none";
    this.vidElement2!.nativeElement.pause();

    this.vidElement3!.nativeElement.style.display = "none";
    this.vidElement3!.nativeElement.pause();
  }

}
