import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from './base.service';
import MyObjectResponseModel from '../api/response-models/my-object-response.model';
import GetMyObjectParams from '../api/params-models/get-my-object-params.model';

@Injectable({
    providedIn: 'root'
})
export class MyObjectService extends BaseService {
    constructor(protected override httpClient: HttpClient) {
        super(httpClient);
    }

    getMyObjectData({ take, offset }: GetMyObjectParams): Observable<MyObjectResponseModel[]> {
        return this.Get<MyObjectResponseModel[]>(BaseService.MY_OBJECT_ENDPOINT, { take: take, offset: offset });
    }

    getMyObjectStaticData(): Observable<number> {
        return this.Get<number>(BaseService.MY_OBJECT_COUNT_ENDPOINT);
    }

    addMyObjectData(body: string): Observable<number> {
        return this.Post<number>(BaseService.MY_OBJECT_ENDPOINT, body);
    }
}